using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushEffect : MonoBehaviour
{
    public float rushSpeed = 20.0f;
    private void Update()
    {
        if(Player.instance.verticalSpeed != rushSpeed)
        {
            Player.instance.verticalSpeed = rushSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            MonsterTakeDamage monsters = collision.gameObject.GetComponent<MonsterTakeDamage>();

            if (monsters != null)
            {
                //9999ดย ม๏ป็
                monsters.TakeDamage(9999);
            }
        }
    }
}
