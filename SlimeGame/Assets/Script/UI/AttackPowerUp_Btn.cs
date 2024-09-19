using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerUp_Btn : MonoBehaviour
{
    AudioSource audioSource;

    public AudioClip sellingSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PowerUpButton()
    {
        ShopItem shopItem = GetComponentInParent<ShopItem>();


        if(shopItem != null )
        {
            if(Player.instance.getGold >= shopItem.itemValue)
            {

                Player.instance.getGold -= shopItem.itemValue;

                EffectSoundManager.instance.PlaySound(sellingSound);

                //50�� ���ݷ� ������ ��ġ
                Player.instance.attackPower += 50;
            }
        }
    }
}
