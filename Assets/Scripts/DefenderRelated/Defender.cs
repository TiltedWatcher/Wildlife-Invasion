using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour{
    [SerializeField] int sunsCost;

    Demolition demolition;
    private void Start() {
        demolition = FindObjectOfType<Demolition>();
    }

    public void addSuns(int maxAmount) {
        int amount = Random.Range(1, (maxAmount +1));
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
