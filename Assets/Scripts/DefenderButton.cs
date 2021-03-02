using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour{
    [SerializeField] Defender defender;

    DefenderSpawner defenderSpawner;

    private void Start() {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(45,45,45,255);
        }
        
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectDefender(defender);

    }
}
