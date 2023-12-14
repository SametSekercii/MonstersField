using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectables
{
    public int spawnPointIndex;
    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.OnCollectCoin, OnCollect);
    }
    private void OnDisable()
    {
        EventManager.AddHandler(GameEvent.OnCollectCoin, OnCollect);

    }
    public override void OnCollect()
    {
        GameManager.Instance.gameData.playerCoin += 1;
        gameObject.SetActive(false);
        Debug.Log("Coin Collected");
        //EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCoinCollect");
    }

    


}
