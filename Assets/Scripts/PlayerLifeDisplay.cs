using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLifeDisplay : MonoBehaviour{

    [SerializeField] int playerStartingLifeCount = 10;

    TextMeshProUGUI lifesText;
    int currentLifeCount;


    void Start() {
        currentLifeCount = playerStartingLifeCount;
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

    public int removeLifes(int amount) {
        currentLifeCount -= amount;
        UpdateDisplay();
        return currentLifeCount;
    }
}
