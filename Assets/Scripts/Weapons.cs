using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public WeaponStats stats;
    protected Rigidbody rb;

    public abstract void Move(Transform target,float speed);
    
    

}
