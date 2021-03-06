using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour{

    //master keys
    const string MASTER_VOLUME_KEY = "MasterVolume" ;
    const string DIFFICULTY_KEY = "Difficulty";


    //other keys
    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f; 
    const float MIN_DIFFICULTY = 0f;
    const float MAX_DIFFICULTY = 2f;

    public static void SetMasterVolume(float volume) {

        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range. Attempted to set volume as " + volume);        
        }
        
    }

    public static float GetMasterVolume() {
        float volume;

        if (PlayerPrefs.HasKey(MASTER_VOLUME_KEY)) {
            volume = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        } else {
            /* var settings = FindObjectOfType<SettingsController>();

             if (settings == null) {
                 settings = new SettingsController();
             } 

             volume = settings.getDefaultVolume(); */
            volume = SettingsController.getDefaultVolume();
        }

        return volume;
    }

    public static void SetDifficulty(float difficulty) {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY) {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        } else {
            Debug.LogError("Something got fucked. Difficulty out of range. Attempted to set difficulty as " + difficulty);
        }
    }

    public static float GetDifficulty() {

        float difficulty;

        if (PlayerPrefs.HasKey(DIFFICULTY_KEY)) {
            difficulty = PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        } else {
           /* var settings = FindObjectOfType<SettingsController>();
            if (settings == null) {
                settings = new SettingsController();
            }*/
            difficulty = SettingsController.getDefaultDifficulty();
        }

        return difficulty;
    }
}
