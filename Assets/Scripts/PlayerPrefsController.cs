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

    public static void SetMasterVolume(float volume) {

        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME) {
            Debug.Log("Master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range. Attempted to set volume as " + volume);        
        }
        
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }
}
