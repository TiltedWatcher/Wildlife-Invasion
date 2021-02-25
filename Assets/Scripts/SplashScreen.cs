using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour{

    [SerializeField] float splashScreenTimer = 3f;
    // Start is called before the first frame update
    void Start(){
        var sceneLoader = GetComponent<SceneLoader>();
        sceneLoader.loadMainMenu(splashScreenTimer);
    }

    // Update is called once per frame
    void Update(){
        
    }
}
