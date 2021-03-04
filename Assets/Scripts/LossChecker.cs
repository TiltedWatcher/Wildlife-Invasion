using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossChecker : MonoBehaviour{

    //cached references
    PlayerLifeDisplay lifeDisplay;

    private void Start() {
        lifeDisplay = FindObjectOfType<PlayerLifeDisplay>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Attacker>()) {
            lifeDisplay.removeLifes(otherObject.GetComponent<Attacker>().PlayerLifeDamage);
        }

    }

}
