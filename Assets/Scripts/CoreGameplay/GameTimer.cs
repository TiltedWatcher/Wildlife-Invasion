using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour{

    float levelDuration;
    float timePassed;

    Slider slider;
    LevelControler level;

    bool triggeredLevelEnd;

    public float LevelDuration {
        get => levelDuration;
        set => levelDuration=value;
    }

    private void Start() {
        slider = GetComponent<Slider>();
        level = FindObjectOfType<LevelControler>();
    }


    // Update is called once per frame
    void Update(){
        if (triggeredLevelEnd) {
            return;
        }
        slider.value = Time.timeSinceLevelLoad / levelDuration;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelDuration);

        if (timerFinished) {
            Debug.Log("Stopping all spawners");
            level.LevelTimerEnded();
            triggeredLevelEnd = true;
        }
    }
}
