using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour{

    [SerializeField][Range(0f,10f)] float walkSpeedMultiplier = 1f;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeedMultiplier);
    }
}
