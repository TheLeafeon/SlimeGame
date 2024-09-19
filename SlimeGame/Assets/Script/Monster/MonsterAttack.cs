using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Collider2D currentCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentCollider = collision;
        }
    }

    private void Update()
    {
        if (currentCollider != null)
        {
            PlayerTakeDamage player = currentCollider.GetComponent<PlayerTakeDamage>();
            Monster monster = GetComponentInParent<Monster>();
            if (player != null)
            {
                
                player.TakeDamage(monster.monsterAttackPower);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == currentCollider)
        {
            currentCollider = null;
        }
    }
}