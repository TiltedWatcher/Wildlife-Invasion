using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour{
    //parameters
    [SerializeField] float startHealth = 100f;
    [SerializeField] GameObject deathVFX;

    //states
    [SerializeField] float currentHealth; //serialized for monitoring purpose

    private void Start() {
        currentHealth = startHealth;
    }


    public void DealDamage(float damageDealt) {
        currentHealth -= damageDealt;
  
        if (currentHealth <= 0) {
            PlayDeathVFX();
            Destroy(gameObject);
        }
    
    }

    private void PlayDeathVFX() {
        if (!deathVFX) {
            return;
        }
        var deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 2f);
        ;
    }
}
