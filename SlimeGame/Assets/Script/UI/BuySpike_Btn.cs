using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySpike_Btn : MonoBehaviour
{
    public GameObject Spike;

    AudioSource audioSource;

    public AudioClip sellingSound;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SpikeBuyButton()
    {
        ShopItem shopItem = GetComponentInParent<ShopItem>();


        if (shopItem != null)
        {
            if (Player.instance.getGold >= shopItem.itemValue && !Spike.activeSelf)
            {
                Player.instance.getGold -= shopItem.itemValue;


                EffectSoundManager.instance.PlaySound(sellingSound);

                Spike.SetActive(true);


            }
        }
    }
}
