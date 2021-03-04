using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossChecker : MonoBehaviour{

    //cached references
    LevelControler level;

    private void Start() {
        level = FindObjectOfType<LevelControler>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        var otherObject = collision.gameObject;

        if (otherObject.GetComponent<Attacker>()) {
            level.LifeDamage(otherObject.GetComponent<Attacker>().PlayerLifeDamage);
        }

    }

}
