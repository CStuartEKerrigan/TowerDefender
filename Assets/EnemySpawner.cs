using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,20f)][SerializeField] float timeBetweenSpawns = 2.5f;
    [SerializeField] GameObject spawnType;
    [SerializeField] Transform spawnPoint;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());    
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GameObject spawned = Instantiate(spawnType, spawnPoint.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
