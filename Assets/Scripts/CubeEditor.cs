using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    TextMesh label;
    Waypoint waypoint;
    Vector3 gridPos;
    private void Awake()
    {
        label = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

    private void SnapToGrid()
    {
        waypoint = GetComponent<Waypoint>();
        int gridSize = waypoint.getGridSize();
        gridPos.x = Mathf.RoundToInt(waypoint.GetGridPos().x) * gridSize;
//        gridPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        gridPos.z = Mathf.RoundToInt(waypoint.GetGridPos().y) * gridSize;
        transform.position = new Vector3(gridPos.x, transform.position.y, gridPos.z);
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.getGridSize();
        label.text = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        gameObject.name = label.text;
    }
}
