using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    AudioSource audioSource;

    public AudioClip coinSound;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        UnityEngine.Debug.Log("Projectile Collision with " + collision.gameObject);

        if(collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("°ñµå È¹µæ.");

            EffectSoundManager.instance.PlaySound(coinSound);

            Player.instance.getGold += 1;

           Destroy(gameObject);
        }

            
        
    }
}
