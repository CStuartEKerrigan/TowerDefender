using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudioLibrary : MonoBehaviour
{
    [SerializeField] AudioClip[] speech;
    AudioSource sfx;

    public void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    public void playSpeech(int i)
    {
        if (!sfx.isPlaying)
            sfx.PlayOneShot(speech[i]);
    }


}
