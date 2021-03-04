using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxAttacker : MonoBehaviour{


    private void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject otherObject = otherCollider.gameObject;

        Debug.Log("Collided with something");

        if (otherObject.GetComponent<Defender>()) {
            Debug.Log("Collided with Defender");
            if (otherObject.GetComponent<GraveStone>()) {
                GetComponent<Animator>().SetTrigger("jumpTrigger");
            } else {
                GetComponent<Attacker>().Attack(otherObject);
            }

        }

    }

}
