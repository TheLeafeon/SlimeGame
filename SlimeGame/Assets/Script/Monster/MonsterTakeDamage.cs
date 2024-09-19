using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public bool isInvinsible;
    private BoxCollider2D boxCollider;


    //효과음
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
            if (monsterInformation.monsterHp > 0) //안죽었을때 
            {
                
                monsterAni.SetHitAnimation();
                UnityEngine.Debug.Log("공격 성공. 남은 체력: " + monsterInformation.monsterHp);
            }
            else //죽었을때
            {
                
                UnityEngine.Debug.Log("몬스터 처치");

                //골드 드랍
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
        UnityEngine.Debug.Log("무적 끝");
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
