using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersShooter : MonoBehaviour{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject projectileShooter;

    public void Fire( ) {
        Instantiate(projectile, projectileShooter.transform.position, Quaternion.identity);
        
    }
}
