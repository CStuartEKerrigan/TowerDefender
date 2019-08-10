using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 2.5f;
    [SerializeField] GameObject spawnType;
    [SerializeField] Transform spawnPoint;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());    
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject spawned = Instantiate(spawnType, spawnPoint.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

}
