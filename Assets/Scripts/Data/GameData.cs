using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/GameData", order = 1)]
public class GameData : ScriptableObject
{
    [Header("Float & Int")]
    public int gameLevel = 1;
    public int playerCoin=0;


}
