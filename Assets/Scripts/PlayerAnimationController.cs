using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class PlayerAnimationController
{
    private Animator playerAnimator;
    public PlayerAnimationController(Animator playerAnimator)
    {
        this.playerAnimator = playerAnimator;
    }



    public void SetAnimations(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.isMoving:
                playerAnimator.SetBool("isMoving", true);
                playerAnimator.SetBool("isWaiting", false);
                break;
            case PlayerState.isWaiting:
                playerAnimator.SetBool("isMoving", false);
                playerAnimator.SetBool("isWaiting", true);
                break;
            case PlayerState.isDead:
                playerAnimator.SetBool("isWaiting", false);
                playerAnimator.SetBool("isMoving", false);
               
                break;

        }
    }

    public void StopAttack()
    {
        playerAnimator.SetBool("isAttacking", false);
    }


}