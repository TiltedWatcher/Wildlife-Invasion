using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatLogic : MonoBehaviour{
    
    [SerializeField] bool godMode;
    [SerializeField] [Range(0f, 10f)] float currentTimeScale = 1f;

    // cached references
    SunTracker sunManager;
    LevelControler level;

    void Start(){
        level = FindObjectOfType<LevelControler>();
        sunManager = FindObjectOfType<SunTracker>();
    }

    // Update is called once per frame
    void Update(){

        if(level.LevelRunning){
            CheckCheats();
            Time.timeScale = currentTimeScale;
        }

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
