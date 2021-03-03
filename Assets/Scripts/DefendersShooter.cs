using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShooter : MonoBehaviour{

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject projectileShooter;
    [SerializeField] float projectileSpeed;

    private void Start() {
        setLaneSpawner();
    }

    private void Update() {


        if (isAttackerInLane()) {
            Debug.Log("Shooty McShootface");
            //TODO change animation to shoot
        } else {
            Debug.Log("Ladida do nothing");
            //TODO change animation to idle
        }
    }

    private bool isAttackerInLane() {
        return true;
        throw new NotImplementedException();
    }


    private void setLaneSpawner() {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnersArray) {
        
        }

    }


    public void Fire( ) {
        var projectile = Instantiate(projectilePrefab, projectileShooter.transform.position, Quaternion.identity);
        projectile.Speed = projectileSpeed;
    }
}
