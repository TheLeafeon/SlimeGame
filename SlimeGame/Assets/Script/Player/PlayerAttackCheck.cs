using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackCheck : MonoBehaviour
{

    private Collider2D currentCollider;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
           
            currentCollider = collision;

        }
    }

    private void Update()
    {
        if (currentCollider != null)
        {
            Player.instance.isCombat = true;

            MonsterTakeDamage monsters = currentCollider.GetComponent<MonsterTakeDamage>();

            if (monsters != null)
            {
                
                monsters.TakeDamage(Player.instance.attackPower);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == currentCollider)
        {
            currentCollider = null;

            Player.instance.isCombat = false;
        }
    }
}
