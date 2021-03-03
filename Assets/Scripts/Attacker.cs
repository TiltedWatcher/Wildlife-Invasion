using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour{

 //   [SerializeField][Range(0f,10f)] float moveSpeedMultiplier = 1f;



    //states
    float currentSpeed = 1f;

    private void Start() {
        //currentSpeed = moveSpeedMultiplier;
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector2.left * Time.deltaTime * currentSpeed);
    }

    public void SetMovementSpeed(float speed) {
        currentSpeed = speed;
    }
}
