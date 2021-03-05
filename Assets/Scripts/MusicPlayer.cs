using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour{
    
    
    [SerializeField] AudioClip[] gameMusic;

    AudioSource musicPlayer;
    int currentSongIndex;
    int songCount;
    float rawVolume;

    void Start(){
        
        DontDestroyOnLoad(this);
        musicPlayer = GetComponent<AudioSource>();
        rawVolume = musicPlayer.volume;
        musicPlayer.volume = rawVolume * PlayerPrefsController.GetMasterVolume();
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
        musicPlayer.volume = rawVolume * volume;
    }

    public void DirectlySetRawVolume(float volume) {
        rawVolume = Mathf.Clamp(volume, 0, 1);
        musicPlayer.volume = rawVolume;
    }
}
