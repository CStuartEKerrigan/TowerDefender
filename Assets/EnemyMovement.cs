using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float yieldTime = 1f;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(PrintAllWaypoints(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PrintAllWaypoints(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path){
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(yieldTime);
        }

        print("Ending Patrol");

    }
}
