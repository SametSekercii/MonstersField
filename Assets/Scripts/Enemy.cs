using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Characters
{
    public Transform target;
    protected NavMeshAgent agent;
    
    public override void TakeDamage(float damage)
    {
        if(isAlive)
        {
            Health -= damage;
        }

        if (Health<=0) isAlive = false;
        
    }
}
