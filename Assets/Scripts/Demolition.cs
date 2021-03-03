using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolition : MonoBehaviour{

    [SerializeField] bool demolitionMode = false;
    [SerializeField] Texture2D demolishTexture;

    public bool DemolitionMode {
        get => demolitionMode;
        set => demolitionMode=value;
    }

    CursorMode cursorMode = CursorMode.Auto;
    Vector2 mouseHotSpot = Vector2.zero;

    private void OnMouseDown() {

        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(45, 45, 45, 255);
        }
        

        toggleDemolitionMode(!demolitionMode);   
    }

    public void toggleDemolitionMode(bool toggleTo) {
        demolitionMode = toggleTo;

        if (demolitionMode) {
            GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectDefender(null);
            Cursor.SetCursor(demolishTexture, mouseHotSpot, cursorMode);

        } else {
            GetComponent<SpriteRenderer>().color = new Color32(80, 80, 80, 255);
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
