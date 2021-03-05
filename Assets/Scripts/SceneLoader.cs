using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{

    [SerializeField] int mainMenuIndex = 1;
    [SerializeField] float splashScreenWaitTime;

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0){
            Debug.Log("We're getting there");
            StartCoroutine(loadMainMenu(splashScreenWaitTime));
        }
    }

    public void loadScene(int sceneIndex) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadScene(string sceneName) {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void loadGameOver(float delay) {
        StartCoroutine(loadSceneWithDelay(delay, "GameOver"));
    }

    public void reloadScene() {
        Time.timeScale = 1;
        loadScene(currentSceneIndex);   
    }


    public void loadMainMenu() {
        Time.timeScale = 1;
        loadScene(mainMenuIndex);
    }

    public IEnumerator loadSceneWithDelay(float secondsDelay, int sceneIndex) {
        yield return new WaitForSeconds(secondsDelay);
        loadScene(sceneIndex);
    }

    public IEnumerator loadSceneWithDelay(float secondsDelay, string sceneName) {
        yield return new WaitForSeconds(secondsDelay);
        loadScene(sceneName);
    }

    public IEnumerator reloadSceneWithDelay(float secondsDelay) {
        yield return new WaitForSeconds(secondsDelay);
        loadScene(currentSceneIndex);
    }
    
    public IEnumerator loadMainMenu(float secondsDelay) {
        Debug.Log("loading Main Menu");
        yield return new WaitForSeconds(secondsDelay);
        loadScene(mainMenuIndex);
    }

    public IEnumerator loadNextLevel(float secondsDelay) {
        yield return new WaitForSeconds(secondsDelay);
        if (currentSceneIndex +1 < (SceneManager.sceneCountInBuildSettings)) {
            loadScene(currentSceneIndex +1);
        } else {
            //TODO reached the last level
        }
    }
}
