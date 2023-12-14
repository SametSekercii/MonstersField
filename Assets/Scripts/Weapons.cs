using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour
{
    public WeaponStats stats;
    protected Rigidbody rb;

    protected abstract void Move(Transform target,float speed);
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log(stats.damage);
            damageable.TakeDamage(stats.damage);
            gameObject.SetActive(false);
        }

    }

}
