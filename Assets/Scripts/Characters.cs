using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Characters : MonoBehaviour,IDamageable
{
    public bool isAlive = true;

    
    protected Rigidbody rb;
    protected Animator animator;
    [SerializeField]private float health;
    public float Health { get { return health; } set { value = health; } }


    public abstract void TakeDamage(float damage);









}
