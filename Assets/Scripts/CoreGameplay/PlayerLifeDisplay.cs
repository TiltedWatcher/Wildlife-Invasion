using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeDisplay : MonoBehaviour{


    TextMeshProUGUI lifesText;
    LevelControler levelControler;
    float currentLifeCount;


    void Start() {
        levelControler = FindObjectOfType<LevelControler>();
        currentLifeCount = levelControler.Lifes;
        lifesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        lifesText.text = currentLifeCount.ToString();

    }

    public void addLifes(int amount) {
        currentLifeCount += amount;
        UpdateDisplay();
    }

    public float removeLifes(int amount) {
        currentLifeCount -= amount;
        UpdateDisplay();
        return currentLifeCount;
    }
}
