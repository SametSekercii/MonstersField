using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Float & Int")]
    public int playerKill = 0;
    public int playerCoin=0;


}
