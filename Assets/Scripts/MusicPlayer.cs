using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour{
    
    
    [SerializeField] AudioClip[] gameMusic;

    AudioSource musicPlayer;
    int currentSongIndex;
    int songCount;

    void Start(){
        DontDestroyOnLoad(this);
        musicPlayer = GetComponent<AudioSource>();
        musicPlayer.volume *= PlayerPrefsController.GetMasterVolume();
        songCount = gameMusic.Length;
    }

    private void Update() {
        loopMusic();
    }

    private void loopMusic() {
        if (musicPlayer.isPlaying) {
            return;
        } else {
            musicPlayer.loop = false;
            musicPlayer.clip =  randomSong();
            musicPlayer.Play();
        }
    }

    private AudioClip randomSong() {
        currentSongIndex = Random.Range(0, songCount);
        return gameMusic[currentSongIndex];
        
    }

    public void SetVolume(float volume) {
        musicPlayer.volume *= volume;
    }

    public void DirectlySetVolume(float volume) {
        volume = Mathf.Clamp(volume, 0, 1);
        musicPlayer.volume = volume;
    }
}
