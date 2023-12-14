using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boomerang : Weapons
{
    public override void Move(Transform target, float speed)
    {
        StartCoroutine(MoveCoroutine(target, speed));
    }

    private void Start()
    {
        StartCoroutine(SelfDestroy());
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if (damageable != null && other.CompareTag("Enemy"))
        {
            Debug.Log(stats.damage);
            damageable.TakeDamage(stats.damage);
            gameObject.SetActive(false);
        }

    }

    IEnumerator MoveCoroutine(Transform target, float speed)
    {
        while (true)
        {

            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            yield return null;  
        }
    }
    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
