using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour{

    [SerializeField] int playerStartingLifes = 10;
    [SerializeField] float gameOverDelay = 2f;
    [Tooltip("Level Duration in seconds")]
    [SerializeField] float gameDuration = 60f;


    //cached references
    SceneLoader sceneLoader;
    PlayerLifeDisplay playerLifeDisplay;

    //states
    int numberOfAttackersAlive = 0;
    int currentLifeCount;
    bool levelTimerFinished;


    void Start(){
        FindObjectOfType<GameTimer>().LevelDuration = gameDuration;
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerLifeDisplay = FindObjectOfType<PlayerLifeDisplay>();
    }


    public void LifeDamage(int amount) {
        currentLifeCount = playerLifeDisplay.removeLifes(amount);

        if (currentLifeCount <= 0) {
            GameOver();
        }
    }

    private void Update() {
    }

    private void GameOver() {


        sceneLoader.loadGameOver(gameOverDelay);
    }

    public int Lifes {
        get => playerStartingLifes;
    }

    public void AttackerHasSpawned() {
        numberOfAttackersAlive++;
    }

    public void AttackerWasDestroyed() {
        numberOfAttackersAlive--;
        EndOfLevel();
    }

    private void EndOfLevel() {
        Debug.Log("Test");
        if (numberOfAttackersAlive <= 0 && levelTimerFinished) {
            Debug.Log("You did it!");
        } else {
            return;
        }
    }

    public void LevelTimerEnded() {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners() {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnerArray) {
            spawner.StopSpawning();
        }
    }
}
