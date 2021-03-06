using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenderButton : MonoBehaviour{
    [SerializeField] Defender defender;
    [SerializeField] bool isDefaultButton = false;

    DefenderSpawner defenderSpawner;
    Demolition demoButton;

    private void Start() {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
        demoButton = FindObjectOfType<Demolition>();
        if (isDefaultButton) {
            selectDefender();
        }

        LabelButtonWithCost();
            
        
    }

    private void LabelButtonWithCost() {
        TextMeshPro costText = GetComponentInChildren<TextMeshPro>();

        Debug.Log("Number of text meshes" + GetComponentsInChildren<TextMeshPro>().Length);

        Debug.Log(costText.text);
        if (!costText) {
            Debug.LogError(name + " has no TextLabel");
        } else {
            costText.text = defender.getSunCost().ToString();
            Debug.Log("Test");
        }
    }

    private void OnMouseDown() {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach (DefenderButton button in buttons) {
            button.GetComponent<SpriteRenderer>().color = new Color32(45, 45, 45, 255);
        }
        demoButton.toggleDemolitionMode(false);
        

        selectDefender();

    }

    private void selectDefender() {
        GetComponent<SpriteRenderer>().color = Color.white;
        defenderSpawner.SetSelectDefender(defender);
    }
}
