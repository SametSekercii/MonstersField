using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonEnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private int skeletonEnemyAmount;
    private int maxSkeletonEnemyAmount;

    private float coolDown;
    private float spawnRate;


    private void Start()
    {
        skeletonEnemyAmount = 0;
        maxSkeletonEnemyAmount = 4;
        coolDown = 15;
        spawnRate = 3;

        StartCoroutine(SpawnSkeleton());
    }

    IEnumerator SpawnSkeleton()
    {
        yield return new WaitForSeconds(2);
        while (true) 
        {
            
            while (skeletonEnemyAmount<maxSkeletonEnemyAmount)
            {
               int rand = Random.Range(0,spawnPoints.Length);

                var skeleton = ObjectPooler.Instance.GetSkeletonEnemyFromPool();

                if(skeleton != null)
                {
                    skeleton.transform.position = spawnPoints[rand].position;
                    skeleton.SetActive(true);
                    skeletonEnemyAmount++;
                }
                yield return new WaitForSeconds(spawnRate);

            }
            yield return new WaitForSeconds(coolDown);

        }
    }
         

}
