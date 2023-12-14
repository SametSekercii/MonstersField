using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : UnitySingleton<ObjectPooler>
{

    #region SkeletonEnemy

    public GameObject skeletonEnemyPrefab;
    public List<GameObject> skeletonEnemyPool;
    private int amountOfSkeletonEnemy = 10;





    public GameObject GetSkeletonEnemyFromPool()
    {
        for (int i = 0; i < amountOfSkeletonEnemy; i++)
        {
            if (!skeletonEnemyPool[i].activeSelf) return skeletonEnemyPool[i];
        }
        return null;
    }

    public void CreateSkeletonEnemyPool()
    {
        for (int i = 0; i < amountOfSkeletonEnemy; i++)
        {
            var SkeletonEnemy = Instantiate(skeletonEnemyPrefab);
            SkeletonEnemy.transform.SetParent(transform);
            SkeletonEnemy.SetActive(false);
            skeletonEnemyPool.Add(SkeletonEnemy);
        }
    }
    #endregion

    #region Boomerang

    public GameObject boomerangPrefab;
    public List<GameObject> boomerangPool;
    private int amountOfBoomerang = 10;





    public GameObject GetBoomerangFromPool()
    {
        for (int i = 0; i < amountOfBoomerang; i++)
        {
            if (!boomerangPool[i].activeSelf) return boomerangPool[i];
        }
        return null;
    }

    public void CreateBoomerangPoolPool()
    {
        for (int i = 0; i < amountOfSkeletonEnemy; i++)
        {
            var boomerang = Instantiate(skeletonEnemyPrefab);
            boomerang.transform.SetParent(transform);
            boomerang.SetActive(false);
            boomerangPool.Add(boomerang);
        }
    }
    #endregion
    private void Start()
    {
        CreateSkeletonEnemyPool();
    }
}