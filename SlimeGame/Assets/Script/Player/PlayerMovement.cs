using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

            if (!Player.instance.isCombat)
            {
                //UnityEngine.Debug.Log("이동중");
                Vector2 move = new Vector2(rigidbody2d.velocity.x, 1.0f);

                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, move.y * Player.instance.verticalSpeed);
                animator.SetBool("isCombat", false);
            }
            else
            {
                //UnityEngine.Debug.Log("이동 불가");
                rigidbody2d.velocity = Vector2.zero;
                animator.SetBool("isCombat", true);
            }
        
       
    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");


        Vector2 move = new Vector2(horizontal, rigidbody2d.velocity.y);


        rigidbody2d.velocity = new Vector2(move.x * Player.instance.horizontalSpeed, rigidbody2d.velocity.y);
    }


}
