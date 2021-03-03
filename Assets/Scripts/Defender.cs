using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour{
    [SerializeField] int sunsCost;

    public void addSuns(int amount) {
        FindObjectOfType<SunTracker>().addSuns(amount);

    }

    public int getSunCost() {
        return sunsCost;
    
    }

}
