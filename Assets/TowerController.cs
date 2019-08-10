using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform objectToTurn;
    [SerializeField] Transform target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        objectToTurn.LookAt(target);
    }
}
