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
                //�������� �԰� ���׾��� ��
                UnityEngine.Debug.Log("�÷��̾ �������� �Ծ����ϴ�.");
            }
            else
            {
                UnityEngine.Debug.Log("�÷��̾� ���");
                //�׾��� ��
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
