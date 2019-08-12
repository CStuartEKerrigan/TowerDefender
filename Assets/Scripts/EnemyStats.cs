using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int health = 3;
    [SerializeField] int scoreValue = 100;
    AudioSource sfx;
    [SerializeField] AudioClip[] suicideSpeech;
    [SerializeField]GameObject deathParticles, hitParticles, goalParticle;
    [Range(0f,1f)][SerializeField] float speechChance;

    private bool suicidal = false;
    bool speaker;
    void Start()
    {
        speaker = Random.value < speechChance;
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
        health--;
    }

    private void CheckDeath()
    {
        if (suicidal) return;

         if (health <= 0)
        {
            DestroyEnemy();
        }
        else
        {
            DamageEnemy();
        }
    }

    private void DamageEnemy()
    {
        sfx.PlayOneShot(sfx.clip);
        PlayAndKillParticle(hitParticles);
    }

    private void PlayAndKillParticle(GameObject particle)
    {
        var fx = Instantiate(particle, transform.position, Quaternion.identity);
        float lifetime = fx.GetComponent<ParticleSystem>().main.duration;
        Destroy(fx, lifetime);
    }

    public void DestroyEnemy()
    {
        FindObjectOfType<FriendlyBase>().increaseScore(100);

        AudioSource.PlayClipAtPoint(sfx.clip, transform.position);
        PlayAndKillParticle(deathParticles);
        Destroy(gameObject);
    }

    public void EndGoal()
    {
        suicidal = true;
        if (speaker)
        {
            Speech();
        }
        else
        {
            Suicide();
        }
    }

    public void Speech()
    {
        speaker = false;
        int monologue = Random.Range(0, suicideSpeech.Length);
        AudioSource.PlayClipAtPoint(suicideSpeech[monologue], Camera.main.transform.position);
        Suicide();
    }

    public void Suicide()
    {
        FindObjectOfType<FriendlyBase>().DecreaseHealth(1);
        PlayAndKillParticle(goalParticle);
        Destroy(gameObject);
    }
    

}
