using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour{

    [SerializeField] GameObject defender;
    [SerializeField][Range(-0.3f,0.3f)] float spawnOffsetY = 0.16f;
    private void OnMouseDown() {

        SpawnDefender(GetSquareClicked());
    }


    private void SpawnDefender(Vector2 spawnPos) {
        GameObject newDefender = Instantiate(defender, spawnPos, Quaternion.identity) as GameObject;

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
        float newY = Mathf.RoundToInt(rawWorldPos.y) + spawnOffsetY;
        return new Vector2(newX, newY);
    }

}
