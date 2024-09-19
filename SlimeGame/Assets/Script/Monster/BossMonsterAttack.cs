using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMonsterAttack : MonoBehaviour
{
    public GameObject[] bulletPosition;
    private Coroutine slimeCoroutine;
    public GameObject SlimeBallProjectile;

    //공날리기 시작 여부
    private bool ballAttack = false;

    private void Start()
    {
    }

    private void Update()
    {
        Monster monsterInformation = GetComponentInParent<Monster>();

        
        if (monsterInformation.monsterHp <= 0)
        {
            StopCoroutine(slimeCoroutine);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             if(!ballAttack)
            {
                ballAttack = true;

                slimeCoroutine = StartCoroutine(SlimeBall());
            }
        }
    }

    private IEnumerator SlimeBall()
    {

        
        while(true)
        {
            //공격

            UnityEngine.Debug.Log("슬라임 볼 공격" );

            ShuffleArray(bulletPosition);
            GameObject[] randomSelection = new GameObject[3];

            Array.Copy(bulletPosition, randomSelection, 3);

            for(int i = 0; i< randomSelection.Length; i++)
            {
                Instantiate(SlimeBallProjectile, randomSelection[i].transform.position, randomSelection[i].transform.rotation);
            }

            yield return new WaitForSeconds(2.0f);
        }
    }

    private void ShuffleArray(GameObject[] array)
    {
        System.Random rand = new System.Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = rand.Next(0, i + 1);
           
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
