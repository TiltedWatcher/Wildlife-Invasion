using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demolition : MonoBehaviour{

    [SerializeField] bool demolitionMode = false;

    public bool DemolitionMode {
        get => demolitionMode;
        set => demolitionMode=value;
    }

    private void OnMouseDown() {

        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(45, 45, 45, 255);
        }
        GetComponent<SpriteRenderer>().color = new Color32(80, 80, 80, 255);

        toggleDemolitionMode();   
    }

    public void toggleDemolitionMode() {
        demolitionMode = !demolitionMode;

        if (demolitionMode) {
            GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectDefender(null);
        }
    }
}
