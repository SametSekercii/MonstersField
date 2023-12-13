using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class PlayerController : Characters
{
    public enum PlayerState { isMoving, isAttacking, isWaiting, isDead }
    public PlayerState state;
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;
  
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new PlayerMovement(transform, rb, moveSpeed);
        PlayerAnimationController = new PlayerAnimationController(animator);

    }

    void FixedUpdate()
    {

        CheckState();
        PlayerAnimationController.SetAnimations(state);

        if (isAlive)
        {
            _playerMovement.Movement(_playerInput.moveVector);
        }


    }

    private void CheckState()
    {

        if (isAlive)
        {
            if (_playerInput.moveVector.magnitude > 0)
            {
                state = PlayerState.isMoving;
            }
            else
            {
                state = PlayerState.isWaiting;
            }

        }
        else state=PlayerState.isDead;
    }

}