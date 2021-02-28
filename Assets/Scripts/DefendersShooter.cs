using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShooter : MonoBehaviour{

    [SerializeField] Projectile projectilePrefab;
    [SerializeField] GameObject projectileShooter;
    [SerializeField] float projectileSpeed;

    public void Fire( ) {
        var projectile = Instantiate(projectilePrefab, projectileShooter.transform.position, Quaternion.identity);
        projectile.Speed = projectileSpeed;
    }
}
