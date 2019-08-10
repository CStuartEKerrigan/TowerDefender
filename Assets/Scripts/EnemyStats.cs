using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 3;
    AudioSource sfx;
    [SerializeField]GameObject deathParticles, hitParticles;
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
        sfx.PlayOneShot(sfx.clip); // play as one-shot to prevent death ending sfx.
        health--;
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            DestroyEnemy();
        }
        else
        {
            GameObject wound = Instantiate(hitParticles, transform.position, Quaternion.identity);
            Destroy(wound, 1f);
        }
    }

    private void DestroyEnemy()
    {
        GameObject hit = Instantiate(deathParticles,transform.position,Quaternion.identity);
        Destroy(hit, 1f);
        Destroy(gameObject);
    }
}
