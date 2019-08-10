using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform objectToTurn;
    [SerializeField] Transform target;
    [SerializeField] float attackDistance;
    ParticleSystem.EmissionModule trigger;

    // Start is called before the first frame update
    private void Start()
    {
        trigger = GetComponentInChildren<ParticleSystem>().emission;
    }


    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            objectToTurn.LookAt(target);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance <= attackDistance)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool fire)
    {
        trigger.enabled = fire;
    }

    public float FlatDistanceTo(Vector3 unto)
    {
        Vector2 a = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 b = new Vector2(unto.x, unto.y);
        return Vector2.Distance(a, b);
    }


}
