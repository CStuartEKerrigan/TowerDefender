using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool explored = false;
    Vector2Int gridPosition;
    const int gridSize = 10;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
        (Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }

    public void SetTopColor(Color color)
    {
        Light light = GetComponentInChildren<Light>();
        light.color = color;
    }

}
