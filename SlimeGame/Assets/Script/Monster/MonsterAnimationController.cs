using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        //animator = characterBody.GetComponent<Animator>();
        animator = GetComponent<Animator>();
    }

    public void SetHitAnimation()
    {
        animator.SetTrigger("TakeDamage");
    }

    public void SetDeadAnimation()
    {
        animator.SetBool("isDead", true);
    }


}
