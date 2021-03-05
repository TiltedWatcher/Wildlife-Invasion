using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour{
    
    
    [SerializeField] AudioClip[] gameMusic;

    AudioSource musicPlayer;
    int currentSongIndex;
    int maxSongIndex;

    void Start(){
        DontDestroyOnLoad(this);
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.volume *= PlayerPrefsController.GetMasterVolume();
    }

    public void SetVolume(float volume) {
        musicPlayer.volume *= volume;
    }

    public void DirectlySetVolume(float volume) {
        volume = Mathf.Clamp(volume, 0, 1);
        musicPlayer.volume = volume;
    }
}
