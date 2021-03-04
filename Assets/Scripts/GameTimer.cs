using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour{

    float levelDuration;
    float timePassed;

    Slider slider;

    public float LevelDuration {
        get => levelDuration;
        set => levelDuration=value;
    }

    private void Start() {
        slider = GetComponent<Slider>();
    }


    // Update is called once per frame
    void Update(){
        slider.value = Time.timeSinceLevelLoad / levelDuration;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelDuration);

        if (timerFinished) {
            Debug.Log("Timer expired");
        }
    }
}
