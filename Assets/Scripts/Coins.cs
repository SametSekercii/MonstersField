using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectables
{
 
    
    public override void OnCollect()
    {
        GameManager.Instance.gameData.playerCoin += 1;
        EventManager.Broadcast(GameEvent.OnCollectCoin);
        gameObject.SetActive(false);
        Debug.Log("Coin Collected");
        //EventManager.Broadcast(GameEvent.OnPlaySound, "SoundCoinCollect");
    }

    


}
