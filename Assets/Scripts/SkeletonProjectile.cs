using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonProjectile : Weapons
{

    private void Start()
    {
        StartCoroutine(SelfDestroy());
        //Move(null, stats.speed);
    }
    public override void Move(Transform target, float speed)
    {
        StartCoroutine(MoveCoroutine(target, speed));
    }

    IEnumerator MoveCoroutine(Transform target, float speed)
    {
        while (true)
        {
            transform.position += -transform.forward * Time.deltaTime * speed;
            Vector3 dirV = (target.position - transform.position).normalized;
            Quaternion lookDirection = Quaternion.LookRotation(dirV);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookDirection, 360);
            yield return null;

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null && other.CompareTag("Player"))
        {
            Debug.Log(stats.damage);
            damageable.TakeDamage(stats.damage);
            gameObject.SetActive(false);
        }

    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}