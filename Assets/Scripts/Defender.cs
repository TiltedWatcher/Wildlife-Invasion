using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour{
    [SerializeField] int sunsCost;

    Demolition demolition;
    private void Start() {
        demolition = FindObjectOfType<Demolition>();
    }

    public void addSuns(int amount) {
        FindObjectOfType<SunTracker>().addSuns(amount);

    }

    public int getSunCost() {
        return sunsCost;
    
    }

    private void OnMouseDown() {
        if (demolition.DemolitionMode) {
            Destroy(gameObject);
        }
    }


}
