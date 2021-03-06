using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour{

    [SerializeField] AudioClip errorSound;

    Defender defender;
    int sunCountCurrent;
    AudioSource audioPlayer;
    GameObject defenderParent;

    const string DEFENDER_PARENT_NAME = "Defender";

    private void Start() {
        CreateDefenderParent();
        audioPlayer = GetComponent<AudioSource>();
    }

    private void CreateDefenderParent() {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown() {
        if (defender != null) {
            AttemptToPlaceDefender(GetSquareClicked());
        }
        
    }


    private void SpawnDefender(Vector2 spawnPos) {
        Defender newDefender = Instantiate(defender, spawnPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;

    }

    private Vector2 GetSquareClicked() {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    //converting 
    private Vector2 SnapToGrid(Vector2 rawWorldPos) {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y); //+ spawnOffsetY;
        return new Vector2(newX, newY);
    }

    private void AttemptToPlaceDefender(Vector2 gridPos) {
        var sunDisplay = FindObjectOfType<SunTracker>();
        var defenderCost = defender.getSunCost();

        if (sunDisplay.checkIfEnoughSuns(defenderCost)) {
            SpawnDefender(gridPos);
            sunDisplay.spendStars(defenderCost);
        } else {
            audioPlayer.PlayOneShot(errorSound);
        }
    }

    public void SetSelectDefender(Defender selectedDefender) {
        defender = selectedDefender;
    }

}
