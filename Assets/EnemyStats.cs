using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 3;
    AudioSource sfx;
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        CheckDeath();
    }

    void ProcessHit()
    {
        sfx.PlayOneShot(sfx.clip);
        health--;
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
