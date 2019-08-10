using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    [SerializeField] Waypoint startPoint, endPoint;
    private Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    bool isRunning=true;

    Vector2Int[] directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchCenter;
    private List<Waypoint> path = new List<Waypoint>();

    public List<Waypoint> GetPath() {
        if (path.Count == 0)
        {
            LoadBlocks();
            BreadthFirstSearch();
            FormPath();
        }
        return path;
    }


    private void FormPath()
    {
        path.Add(endPoint);
        Waypoint prev = endPoint.exploredFrom;
        while (prev != startPoint)
        {
            // add intermediate waypoints
            path.Add(prev);
            prev = prev.exploredFrom;
        }
        path.Add(startPoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            isRunning = CheckDestination();
            if (isRunning)
            {
                ExploreNeighbours();
            }
            searchCenter.explored = true;
        }
    }

    private bool CheckDestination()
    {
        return (searchCenter != endPoint);
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int currDirection in directions)
        {
            Vector2Int consideredPosition = searchCenter.GetGridPos() + currDirection;
            ConsiderPosition(consideredPosition);
        }
    }

    private void ConsiderPosition(Vector2Int consideredPosition)
    {
        if (grid.ContainsKey(consideredPosition))
        {
            Waypoint neighbour = grid[consideredPosition];
            if (!neighbour.explored && !queue.Contains(neighbour))
            {
                neighbour.exploredFrom = searchCenter;
                queue.Enqueue(neighbour);
            }
        }
    }

    private void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.black);
        endPoint.SetTopColor(Color.green);
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint way in wayPoints)
        {
            Vector2Int gridPos = way.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Overlapping block");
            }
            else
            {
                grid.Add(gridPos, way);
            }

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
