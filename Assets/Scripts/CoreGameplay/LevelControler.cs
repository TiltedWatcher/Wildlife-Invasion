using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControler : MonoBehaviour{

    [SerializeField] float playerStartingLivesBase = 5;
    [SerializeField] float[] difficultyMultipliers;

    //[SerializeField] float gameOverDelay = 2f;
    [SerializeField] float victoryDelay = 2f;

    [Tooltip("Level Duration in seconds")]
    [SerializeField] float gameDuration = 60f;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject gameOverScreen;


    //cached references
    SceneLoader sceneLoader;
    PlayerLifeDisplay playerLifeDisplay;

    //states
    float playerStartingLifes;
    int numberOfAttackersAlive = 0;
    float currentLifeCount;
    bool levelTimerFinished;
    bool levelRunning = true;


    void Start(){
        playerStartingLifes = Mathf.Round( playerStartingLivesBase * difficultyMultipliers[(int)PlayerPrefsController.GetDifficulty()]);
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
        FindObjectOfType<GameTimer>().LevelDuration = gameDuration;
        sceneLoader = FindObjectOfType<SceneLoader>();
        playerLifeDisplay = FindObjectOfType<PlayerLifeDisplay>();
        Debug.Log("difficulty setting is currently " + PlayerPrefsController.GetDifficulty());
        Debug.Log("difficulty multiplier is currently " + difficultyMultipliers[(int)PlayerPrefsController.GetDifficulty()]);
    }


    public void LifeDamage(int amount) {
        currentLifeCount = playerLifeDisplay.removeLifes(amount);

        if (currentLifeCount <= 0) {
            GameOver();
        }
    }


    private void GameOver() {
        gameOverScreen.SetActive(true);
        levelRunning = false;
        Time.timeScale = 0;
        //sceneLoader.loadGameOver(gameOverDelay);
    }

    public float Lifes {
        get => playerStartingLifes;
    }

    public bool LevelRunning {
        get => levelRunning;
    }

    public void AttackerHasSpawned() {
        numberOfAttackersAlive++;
    }

    public void AttackerWasDestroyed() {
        numberOfAttackersAlive--;
        if (numberOfAttackersAlive <= 0 && levelTimerFinished) {
           HandleEndOfLevel();
        }
    }

    private void HandleEndOfLevel() {
        levelRunning = false;
        victoryScreen.SetActive(true);
        AudioSource winAudio = victoryScreen.GetComponent<AudioSource>();
        winAudio.Play();
        StartCoroutine(sceneLoader.loadNextLevel(victoryDelay));
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
