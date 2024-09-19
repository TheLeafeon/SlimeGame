using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;


    [Header("#Monster Information")]
    public int monsterHp = 100;
    public int monsterAttackPower = 1;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

}
