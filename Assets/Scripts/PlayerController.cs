using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;
using Unity.VisualScripting;


public class PlayerController : Characters
{
    public enum PlayerState { isMoving, isAttacking, isWaiting, isDead }
    public PlayerState state;
    public float moveSpeed;
    public Image healthBar;
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnTakeDamage, OnTakeDamage);
        
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnTakeDamage, OnTakeDamage);

    }


    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
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
        else state = PlayerState.isDead;


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

    public override void TakeDamage(float damage)
    {
        if (isAlive) 
        {
           
            StartCoroutine(TakeDamageSlowly(damage));
            

        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.transform.GetComponent<Collectables>();

        if (collectable != null)
        {
            collectable.OnCollect();

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        

    }

    IEnumerator TakeDamageSlowly(float damage)
    {

        for (int i = 0; i < 10; i++)
        {
            health -= damage / 10;
            healthBar.fillAmount = health / maxHealth;
            yield return new WaitForSeconds(0.03f);

        }
        if (Health <= 0)
        {
            isAlive = false;
            EventManager.Broadcast(GameEvent.OnFail);

        } 
       
        EventManager.Broadcast(GameEvent.OnTakeDamage);
    }

    private void OnTakeDamage()
    {

    }

}