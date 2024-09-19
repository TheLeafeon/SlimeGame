using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundManager : MonoBehaviour
{
    public static EffectSoundManager instance;

    AudioSource audioSource;

    [Header("#Gold Get Sound")]
    public AudioClip coinSound;


    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
