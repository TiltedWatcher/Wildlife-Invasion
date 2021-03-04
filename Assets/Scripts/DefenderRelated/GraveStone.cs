using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveStone : MonoBehaviour{
    private void OnTriggerStay2D(Collider2D collision) {

        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker) {
            //TODO
        }

    }
}
