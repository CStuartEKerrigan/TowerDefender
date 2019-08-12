using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] Transform objectToTurn;
    [SerializeField] Transform target;
    [SerializeField] float attackDistance;
    ParticleSystem.EmissionModule trigger;
    AudioSource sfx;
    public Waypoint point;

    // Start is called before the first frame update
    private void Start()
    {
        trigger = GetComponentInChildren<ParticleSystem>().emission;
        sfx = GetComponentInChildren<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance <= attackDistance)
            {
                objectToTurn.LookAt(target);
                Shoot(true);
            }
            else
            {
                target = null;
            }
        }
        else
        {
            SetTargetEnemy();
            Shoot(false);
        }
    }


    private void Shoot(bool fire)
    {
        trigger.enabled = fire;

        // if we stop firing when we're still playing a sound, don't play anymore but keep playing the current sound in progress
        sfx.loop = fire;
        if (!sfx.isPlaying)
        {
            if (fire)
                sfx.Play();
            else
                sfx.Stop();
        }

    }

    public float FlatDistanceTo(Vector3 unto)
    {
        Vector2 a = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 b = new Vector2(unto.x, unto.y);
        return Vector2.Distance(a, b);
    }

    public void SetTargetEnemy()
    {
        var sceneEnemies = FindObjectsOfType<EnemyStats>();
        if (sceneEnemies.Length == 0) return;

        Transform closestEnemy = sceneEnemies[0].transform;
        float closestDistance = Vector3.Distance(transform.position, sceneEnemies[0].transform.position);

        foreach (EnemyStats testedEnemy in sceneEnemies)
        {
            float testedDistance = Vector3.Distance(transform.position, testedEnemy.transform.position);
            if (testedDistance < closestDistance)
            {
                closestEnemy = testedEnemy.transform;
                closestDistance = testedDistance;
            }
        }
        target = closestEnemy;
    }

}
