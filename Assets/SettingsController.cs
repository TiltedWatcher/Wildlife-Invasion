using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour{

    [SerializeField] Slider volumeSlider;
    //volume multiplied by:
    [SerializeField] float defaultVolume = 0.5f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;

    [SerializeField] float[] difficultyMultipliers;

    MusicPlayer musicPlayer;

    void Start(){
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
        
    }

    // Update is called once per frame
    void Update(){

        if (musicPlayer) {
            musicPlayer.SetVolume(volumeSlider.value);
        } else {
            Debug.LogWarning("No music player found. If the game started without splash screen, that may be the cause.");
        }

    }

    public float getDefaultVolume() {
        return defaultVolume;
    }

    public float getDefaultDifficulty() {
        return defaultDifficulty;
    }

    public void ResetToDefaults() {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void SaveAndExit() {

        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneLoader>().loadMainMenu();
        
    }
}
