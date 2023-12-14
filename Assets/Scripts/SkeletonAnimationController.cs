using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skeleton;

public class SkeletonAnimationController
{
    private Animator animator;

    public SkeletonAnimationController(Animator animator)
    {
        this.animator = animator;
    }
    public void SetAnimations(SkeletonEnemyState state)
    {
        if (state == SkeletonEnemyState.isAttacking)
        {
            animator.SetBool("isWaiting", false);
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
        if (state == SkeletonEnemyState.isChasing)
        {
            animator.SetBool("isWaiting", false);
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);
        }
        if (state == SkeletonEnemyState.isDead)
        {
           
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isDead", true);


        }
    }
}
