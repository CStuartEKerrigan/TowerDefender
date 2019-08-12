using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FriendlyBase : MonoBehaviour
{
    public bool alive = true;
    int score = 0;
    UIAudioLibrary speech;
    [Range(0f, 25f)] [SerializeField] const float damageReportTime = 15f;
    float lastReport = -damageReportTime;
    [SerializeField]Text scoreLabel;
    [SerializeField]Text healthLabel;
    [SerializeField] Text gameOver;
    [SerializeField] GameObject deathParticles;

    // Start is called before the first frame update
    [SerializeField] int health=6;
    float maxHealth;
    Light UILight;
    float intensity;
    private void Start()
    {
        speech = FindObjectOfType<UIAudioLibrary>();
        maxHealth = health;
        UILight = GetComponentInChildren<Light>();
        intensity = UILight.intensity;
        SetScore(0);
    }


    public void increaseScore(int amt)
    {
        SetScore(score + amt);
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        scoreLabel.text = "Score:    " + newScore.ToString("D5");
    }

    public void DecreaseHealth(int amt)
    {
        if (alive)
        {

            SetHealth(health - amt);
        }
    }

    public void SetHealth(int newHealth)
    {
        health=newHealth;
        float percentRemaining = (health / maxHealth);
        healthLabel.text = "Base Shield: " + Mathf.RoundToInt(percentRemaining * 100) + "%";
        UILight.intensity = Mathf.Lerp(.6f, intensity, percentRemaining);
        if (health == 0) Die();
        else DamageReport();



    }

    public void Die()
    {
        gameOver.gameObject.SetActive(true);
        alive = false;
        gameObject.AddComponent<Rigidbody>();
        speech.playSpeech(2);
        PlayAndKillParticle(deathParticles);
        Invoke("Restart", 4f);
     //   Destroy(gameObject, 3f);
    }

    public void DamageReport()
    {
        float timeSinceReport = Time.time - lastReport;
        print(Time.time + " - " + lastReport + " = " + timeSinceReport);
        if (timeSinceReport >= damageReportTime)
        {

            lastReport = Time.time;
            speech.playSpeech(1);
        }
    }


        private void PlayAndKillParticle(GameObject particle)
    {
        var fx = Instantiate(particle, UILight.transform.position, Quaternion.identity, transform);
        fx.transform.localScale = new Vector3(25, 25, 25);
        float lifetime = fx.GetComponent<ParticleSystem>().main.duration;
        Destroy(fx, lifetime);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }


}
