using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour{

    [SerializeField] bool active = true;
    [SerializeField] bool spawnRandomized;
    [SerializeField] float levelStartSpawnDelay;
    [SerializeField] float minSpawnDelay;
    [SerializeField] float maxSpawnDelay;
    [SerializeField] Attacker[] attackerPrefabs;

    int attackerIndex;
    bool spawning = true;

    IEnumerator Start(){

        yield return new WaitForSeconds(levelStartSpawnDelay);

        if (Random.Range(0,2) == 0) {
            SpawnAtacker();
        }

        while (active && spawning) {
            
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAtacker();

        }
    }

    public void StopSpawning() {
        spawning = false;
        StopCoroutine(Start());
    }

    public void restartSpawning() {
        spawning = true;
        StartCoroutine(Start());
    }


    private void SpawnAtacker() {

        if (spawnRandomized) {
            attackerIndex = Random.Range(0, attackerPrefabs.Length);
        } 
       Spawn(attackerPrefabs[attackerIndex]);

    }

    private void Spawn(Attacker attacker) {

        Attacker newAttacker = Instantiate(
           attacker, transform.position, transform.rotation)
           as Attacker;
        newAttacker.transform.parent = transform;

    }

}
