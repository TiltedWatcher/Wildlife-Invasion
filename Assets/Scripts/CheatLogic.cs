using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatLogic : MonoBehaviour{
    
    [SerializeField] bool godMode;
    [SerializeField] [Range(0f, 10f)] float currentTimeScale = 1f;

    // cached references
    SunTracker sunManager;

    void Start(){
        sunManager = FindObjectOfType<SunTracker>();
    }

    // Update is called once per frame
    void Update(){
        CheckCheats();
        Time.timeScale = currentTimeScale;
    }

    private void CheckCheats() {

        if (Input.GetKeyDown(KeyCode.Keypad5)) {
            IncreaseSuns();
        }
        
        
    }

    private void IncreaseSuns() {
        sunManager.addSuns(500);
    }
}
