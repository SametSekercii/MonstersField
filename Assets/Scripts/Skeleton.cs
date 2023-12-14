using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : Enemy
{
    public enum SkeletonEnemyState { isChasing,isAttacking,isDead}

    public SkeletonEnemyState state;
    SkeletonAnimationController animationController;
    public Transform[] rightHand;
    public Weapon weapon;
    public AttackRange attackRange { get; set; }
    private void Start()
    {
        rightHand= FindChildrenWithTag(transform, "Hand");
        weapon=GetComponent<Weapon>();
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
                //Debug.Log("Skeleton is chasing");
                Chase();
              
                break;
            case SkeletonEnemyState.isAttacking:
                //Debug.Log("Skeleton is attacking");
                break;
        }
    }

    public void ThrowProjectile()
    {
        
        var bullet = Instantiate(weapon.prefab, rightHand[0].position, Quaternion.Euler(0, 0, 0), transform);

        Debug.Log("throwed");

    }

    public void CheckIfStillInRange()
    {
        if (GetTargetsInRange().Count ==0)
        {
            state=SkeletonEnemyState.isChasing;
        }
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
}


   



