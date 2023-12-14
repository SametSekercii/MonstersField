using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkeletonProjectile : Weapons
{

    private void Start()
    {

        Move(null, stats.speed);
    }
    protected override void Move(Transform target, float speed)
    {
        StartCoroutine(MoveCoroutine(target, speed));
    }

    IEnumerator MoveCoroutine(Transform target, float speed)
    {
        while (true)
        {
            transform.position += -transform.forward * Time.deltaTime * speed;
            yield return null;

        }

    }
}