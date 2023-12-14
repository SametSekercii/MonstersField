using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : UnitySingleton<ObjectPooler>
{

    #region Coin

    public GameObject CoinPrefab;
    public List<GameObject> CoinPool;
    private int amountOfCoin = 200;





    public GameObject GetCoinFromPool()
    {
        for (int i = 0; i < amountOfCoin; i++)
        {
            if (!CoinPool[i].activeSelf) return CoinPool[i];
        }
        return null;
    }

    public void CreateCoinPool()
    {
        for (int i = 0; i < amountOfCoin; i++)
        {
            var Coin = Instantiate(CoinPrefab);
            Coin.transform.SetParent(transform);
            Coin.SetActive(false);
            CoinPool.Add(Coin);
        }
    }
    #endregion
    private void Start()
    {
        CreateCoinPool();
    }
}