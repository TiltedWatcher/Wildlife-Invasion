using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour{

    [SerializeField] bool active = true;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;
    [SerializeField] Attacker attackerPrefab;

    IEnumerator Start(){
        while (active) {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAtacker();
        }
    }

    // Update is called once per frame
    void Update(){
        
    }

 /*   IEnumerator spawning() {

    } */

    private void SpawnAtacker() {
        Instantiate(attackerPrefab, transform.position, transform.rotation);
    }
}
