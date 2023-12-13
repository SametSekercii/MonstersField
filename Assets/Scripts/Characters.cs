using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Characters : MonoBehaviour
{
    public bool isAlive = true;
    public int level;
    public float moveSpeed;
    protected Transform target;


    protected Rigidbody rb;
    protected Animator animator;

    public int _level { get { return level; } set { value = level; } }
    public bool _isAlive { get { return isAlive; } set { value = isAlive; } }

  
    protected void SetSeenTarget(Transform _target)
    {
        target = _target;
    }


  
   


}
