using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShooter : MonoBehaviour{

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject projectileShooter;
    [SerializeField] float projectileSpeed;

    //cached references
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start() {
        setLaneSpawner();
        animator = GetComponent<Animator>();
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
        var projectile = Instantiate(projectilePrefab, projectileShooter.transform.position, Quaternion.identity);
        projectile.Speed = projectileSpeed;
    }
}
