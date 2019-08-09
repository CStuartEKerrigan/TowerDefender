using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f,20f)]float gridSize = 10f;
    TextMesh label;

    private void Awake()
    {
        label = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize)* gridSize;
        snapPosition.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x,0f,snapPosition.z);
        label.text = snapPosition.x/gridSize + "," + snapPosition.z/gridSize;
  //      gameObject.name = label.text;

    }
}
