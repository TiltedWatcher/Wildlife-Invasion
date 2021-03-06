using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShooter : MonoBehaviour{

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject projectileShooter;
    //[SerializeField] float projectileSpeed;

    //cached references
    AttackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start() {
        setLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent() {
        if (!projectileParent) {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update() {


        if (isAttackerInLane()) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool isAttackerInLane() {
        
        return (myLaneSpawner.gameObject.transform.childCount > 0);
    }


    private void setLaneSpawner() {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnersArray) {
            bool isCloseEnough = (Math.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough) {

                myLaneSpawner = spawner;

            }
        }

    }


    public void Fire( ) {

        //GameObject newProjectile = Instantiate(projectilePrefab, projectileShooter.transform.position, Quaternion.identity) as GameObject;
        var projectile = Instantiate(projectilePrefab, projectileShooter.transform.position, Quaternion.identity);
        projectile.transform.parent = projectileParent.transform;
        //projectile.Speed = projectileSpeed;
    }
}
