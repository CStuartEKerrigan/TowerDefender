using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float yieldTime = 1f;
    static FriendlyBase theBase;
    void Start()
    {
        yieldTime = yieldTime - Random.Range(0, 0.2f);
        if (!theBase) theBase = FindObjectOfType<FriendlyBase>();
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> path = pathfinder.GetPath();
        StartCoroutine(PatrolWayPoints(path));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PatrolWayPoints(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path){
            if (theBase.alive)
            {
                transform.localPosition = waypoint.transform.position;
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y+.1f, transform.localPosition.z);
            }
            yield return new WaitForSeconds(yieldTime);
        }

        DestroyAtDestination();

    }

    void DestroyAtDestination()
    {

        EnemyStats stats = GetComponent<EnemyStats>();        
        stats.EndGoal();

    }

}
