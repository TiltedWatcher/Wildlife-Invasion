using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SunTracker : MonoBehaviour{

    [SerializeField] int startingSunAmount = 100;

    TextMeshProUGUI sunText;
    int currentSunCount;


    void Start(){
        currentSunCount = startingSunAmount;
        sunText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay() {
        sunText.text = currentSunCount.ToString();
    
    }

    public void addSuns(int amount) {
        currentSunCount += amount;
        UpdateDisplay();
    }

    public void spendStars(int amount) {
        if (checkIfEnoughSuns(amount)) {
            currentSunCount -= amount;
            UpdateDisplay();
        }

    }

    public bool checkIfEnoughSuns(int amount) {
        if (amount <= currentSunCount) {
            return true;
        } else {
            return false;
        }
    
    }
}
