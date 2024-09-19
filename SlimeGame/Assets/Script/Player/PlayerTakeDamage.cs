using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        //playerNowHp = Mathf.Clamp(playerNowHp + damage, 0, playerMaxHp);

        if(!Player.instance.isInvinsible)
        {
            UIHealthBar healthBarUI = GetComponentInParent<UIHealthBar>();

            Player.instance.isInvinsible = true;


            Invoke("EndInvinsible", 1.0f);

            Player.instance.nowHp = Mathf.Clamp(Player.instance.nowHp - damage, 0, Player.instance.maxHp);

            healthBarUI.HpCheck();

            if (Player.instance.nowHp > 0)
            {
                //데미지를 입고 안죽었을 때
                UnityEngine.Debug.Log("플레이어가 데미지를 입었습니다.");
            }
            else
            {
                UnityEngine.Debug.Log("플레이어 사망");
                //죽었을 때
            }
        }
        
    }

    private void EndInvinsible()
    {
        if(Player.instance.isInvinsible)
        {
            Player.instance.isInvinsible = false;
        }
        
    }
}
