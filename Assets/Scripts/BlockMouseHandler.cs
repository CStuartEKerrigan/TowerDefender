using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMouseHandler : MonoBehaviour
{
    private Waypoint point;
    [SerializeField] Transform UITransform;

    [SerializeField] GameObject towerPrefab;
    private GameObject tower;

    private void Start()
    {
        tower = null;
        point = GetComponent<Waypoint>();
    }


    private void OnMouseOver()
    {
        print("Mouse over " + point.GetGridPos());
    }

    private void OnMouseDown()
    {
        if (point.isPlaceable && !tower)
        {
            UITransform.transform.position = new Vector3(transform.position.x, UITransform.position.y, transform.position.z);
            tower = Instantiate(towerPrefab, transform.position,Quaternion.identity);
        }
        else
        {
            UITransform.gameObject.GetComponent<AudioSource>().Play();

        }
    }
}
