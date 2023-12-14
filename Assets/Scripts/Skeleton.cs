using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Enemy
{
    public enum SkeletonEnemyState { isChasing,isAttacking,isDead}

    public SkeletonEnemyState state;
    SkeletonAnimationController animationController;
    public AttackRange attackRange { get; set; }
    private void Start()
    {
        attackRange =GetComponent<AttackRange>();
        target=FindObjectOfType<PlayerController>().transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animationController = new SkeletonAnimationController(animator);
    }

    private void Update()
    {
        if(isAlive) { Mission(); }
        else state = SkeletonEnemyState.isDead;

        animationController.SetAnimations(state);




    }
    public List<Transform> GetTargetsInRange() => attackRange.targetsInRange;

    private void Chase()
    {
        Vector3 targetPos = target.position;
        agent.SetDestination(targetPos);


        if (GetTargetsInRange().Count > 0)
        {
            agent.SetDestination(transform.position);
            state = SkeletonEnemyState.isAttacking;
        } 


    }
    void Mission()
    {
        switch (state)
        {
            case SkeletonEnemyState.isChasing:
                Debug.Log("Skeleton is chasing");
                Chase();
              
                break;
            case SkeletonEnemyState.isAttacking:
                Debug.Log("Skeleton is attacking");
                break;
        }
    }

    public void ThrowProjectile()
    {
        Debug.Log("throwed");
        
       
    }

    public void CheckIfStillInRange()
    {
        if (GetTargetsInRange().Count ==0)
        {
            state=SkeletonEnemyState.isChasing;
        }
    }


   


}
