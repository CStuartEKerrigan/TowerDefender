using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMouseHandler : MonoBehaviour
{
    private Waypoint point;
    [SerializeField] Transform UITransform;
    private void Start()
    {
        point = GetComponent<Waypoint>();
    }


    private void OnMouseOver()
    {
        print("Mouse over " + point.GetGridPos());
    }

    private void OnMouseDown()
    {
        if (point.isPlaceable)
        {
            UITransform.transform.position = new Vector3(transform.position.x, UITransform.position.y, transform.position.z);
        }

        print("Clicked on " + point.GetGridPos());
    }
}
