using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour{

 //   [SerializeField][Range(0f,10f)] float moveSpeedMultiplier = 1f;



    //states
    float currentSpeed = 1f;

    //cached references
    GameObject currentTarget;

    void Update(){
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }

    public void Attack(GameObject target) {

        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void HitCurrentTarget(float damage) {
        if (!currentTarget) {
            return;
        }
            HealthManager health = currentTarget.GetComponent<HealthManager>();

        if (health) {
            health.DealDamage(damage);
        }

    }

}
