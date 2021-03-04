using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttacker : MonoBehaviour{


    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Defender>()) {
            if (otherObject.GetComponent<GraveStone>()) {
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            } else {
                GetComponent<Attacker>().Attack(otherObject);
            }

        }

    }

}
