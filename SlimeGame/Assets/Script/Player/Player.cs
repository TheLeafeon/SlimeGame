using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("#Player Information")]
    public int maxHp = 100;
    public int nowHp = 100;
    public int attackPower = 1;
    public int getGold = 0;
    public float horizontalSpeed = 10.0f;
    public float basicHorizontalSpeed = 10.0f;
    public float verticalSpeed = 10.0f;
    public float basicVerticalSpeed = 10.0f;


    [Header("#Player State")]
    public bool isCombat = false;
    public bool isInvinsible = false;
    public bool isRush = false;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerStop()
    {
        horizontalSpeed = 0.0f;
        verticalSpeed = 0.0f;
    }
    public void PlayerMove()
    {
        horizontalSpeed = basicHorizontalSpeed;
        verticalSpeed = basicVerticalSpeed;
    }
}
