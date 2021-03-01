using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour{
    //parameters
    [SerializeField] float startHealth = 100f;

    //states
    float currentHealth;

    private void Start() {
        currentHealth = startHealth;
    }


    public void DealDamage(float damageDealt) {
        currentHealth -= damageDealt;
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    
    }
}
