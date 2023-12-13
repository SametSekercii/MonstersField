using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : UnitySingleton<GameManager>
{
    public GameData gameData;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Debug.Log("sa");

    }

    void Start()
    {

        InvokeRepeating("SaveData", 0.05f, 0.05f);
        EventManager.Broadcast(GameEvent.OnStart);

    }


    void Update()
    {

    }
    void SaveData()
    {
        SaveManager.SaveData(gameData);
    }

    private void OnEnable()
    {
       
    }
    private void OnDisable()
    {
        
    }
    
}