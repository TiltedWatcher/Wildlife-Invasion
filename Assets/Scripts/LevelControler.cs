using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour{

    [SerializeField] int playerStartingLifes = 10;
    [SerializeField] float gameOverDelay = 2f;


    //cached references
    SceneLoader sceneLoader;
    PlayerLifeDisplay playerLifeDisplay;

    int currentLifeCount;

    void Start(){
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerLifeDisplay = FindObjectOfType<PlayerLifeDisplay>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void LifeDamage(int amount) {
        currentLifeCount = playerLifeDisplay.removeLifes(amount);

        if (currentLifeCount <= 0) {
            GameOver();
        }
    }

    private void GameOver() {


        sceneLoader.loadGameOver(gameOverDelay);
    }

    public int Lifes {
        get => playerStartingLifes;
    }
}
