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
    public Weapon weapon;
    private float throwSpeed;
    private float timeCounter;
    public AttackRange attackRange { get; set; }
    PlayerMovement _playerMovement;
    PlayerAnimationController PlayerAnimationController;
    PlayerInput _playerInput;
    public Transform[] rightHand;

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnTakeDamage, OnTakeDamage);
        
    }

    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.OnTakeDamage, OnTakeDamage);

    }
    public Transform[] FindChildrenWithTag(Transform parent, string tag)
    {

        List<Transform> childrenWithTag = new List<Transform>();


        foreach (Transform child in parent)
        {

            if (child.CompareTag(tag))
            {
                childrenWithTag.Add(child);
            }


            if (child.childCount > 0)
            {
                childrenWithTag.AddRange(FindChildrenWithTag(child, tag));
            }
        }


        return childrenWithTag.ToArray();
    }
    public List<Transform> GetTargetsInRange() => attackRange.targetsInRange;


    void Start()
    {
        throwSpeed = 2f;
        rightHand = FindChildrenWithTag(transform, "Hand");
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
        attackRange = GetComponent<AttackRange>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _playerMovement = new PlayerMovement(transform, rb, moveSpeed);
        PlayerAnimationController = new PlayerAnimationController(animator);

    }

    void FixedUpdate()
    {

        PlayerAnimationController.SetAnimations(state);
        if (isAlive)
        {
            //CheckRange();
            CheckState();
            
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
        
        if(collision.transform.CompareTag("enemy"))
        {
            TakeDamage(health);
        }

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

    void CheckRange()
    {

        if(attackRange.targetsInRange.Count>0) 
        {
            if((timeCounter += Time.deltaTime) > throwSpeed)
            {
                if(attackRange.targetsInRange[0]!=null)
                {
                    ThrowBoomerang(attackRange.targetsInRange[0]);
                    //Debug.Log(attackRange.targetsInRange);
                    timeCounter = 0;

                }
                
            }
            
        }
    }

    

    void ThrowBoomerang(Transform target)
    {
        var Boomerang = ObjectPooler.Instance.GetBoomerangFromPool();

        if(Boomerang != null)
        {
            Boomerang.transform.position = rightHand[0].position;
            Boomerang.SetActive(true);
            Boomerang.GetComponent<Weapons>().Move(target.transform,Boomerang.GetComponent<Weapons>().stats.speed);
        }

    }

}