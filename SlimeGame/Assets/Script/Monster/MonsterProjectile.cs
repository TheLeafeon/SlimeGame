using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public int projectileDamage = 0;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

    }

    void Update()
    {


        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerTakeDamage player = collision.gameObject.GetComponent<PlayerTakeDamage>();

            if (player != null)
            {
                UnityEngine.Debug.Log("슬라임볼 공격 성공");
                player.TakeDamage(projectileDamage);
            }

            Destroy(gameObject);
        }

        
    }
}
