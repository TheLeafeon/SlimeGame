using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public bool isInvinsible;
    private BoxCollider2D boxCollider;


    //ȿ����
    AudioSource audioSource;

    public AudioClip monsterHit;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        isInvinsible = false;
    }

    public void TakeDamage(int damage)
    {
        Monster monsterInformation = GetComponent<Monster>();
        MonsterAnimationController monsterAni = GetComponent<MonsterAnimationController>();

        if (!isInvinsible)
        {
            monsterInformation.monsterHp -= damage;
            PlaySound(monsterHit);
            if (monsterInformation.monsterHp > 0) //���׾����� 
            {
                
                monsterAni.SetHitAnimation();
                UnityEngine.Debug.Log("���� ����. ���� ü��: " + monsterInformation.monsterHp);
            }
            else //�׾�����
            {
                
                UnityEngine.Debug.Log("���� óġ");

                //��� ���
                GoldDrop goldDrop = GetComponent<GoldDrop>();

                if(goldDrop != null)
                {
                    goldDrop.Drop(transform.position, Quaternion.identity);
                }


                monsterAni.SetDeadAnimation();

                if (boxCollider != null)
                {
                    boxCollider.enabled = false;
                }

                rigidbody2d.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);

                Invoke("DestroyMonster", 0.5f);
            }

            isInvinsible = true;
        }

    }

    public void InvinsibleEnd()
    {
        isInvinsible = false;
        UnityEngine.Debug.Log("���� ��");
    }

    public void DestroyMonster ()
    {
        Destroy(gameObject);
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
