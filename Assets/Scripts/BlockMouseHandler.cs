using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMouseHandler : MonoBehaviour
{
    private Waypoint point;
    private TowerFactory factory;


    private void Start()
    {
        factory = FindObjectOfType<TowerFactory>();
        point = GetComponent<Waypoint>();
    }


    private void OnMouseDown()
    {
        factory.AddTower(point);
    }
}
