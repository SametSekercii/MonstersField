using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UIManager : UnitySingleton<UIManager>
{
    GameManager gameManager;
    GameData gameData;

    [Space(15)]
    [Header("Definitions")]

    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject joystick;
    

    //[Space(15)]
    //[Header("Arrays")]


    //[Space(15)]
    //[Header("Float&Int")]
   

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameData = gameManager.gameData;

    }

    private void OnEnable()
    {
       
        EventManager.AddHandler(GameEvent.OnFail, OnFail);
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
    }
    private void OnDisable()
    {
        
        EventManager.RemoveHandler(GameEvent.OnFail, OnFail);
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
    }
   
    private void OnFail()
    {
        OpenPanel(failPanel, "SoundPanelPop");
        DisableJoyStick();
    }

    private void OnStart()
    {
        
    }
    private void DisableJoyStick() => joystick.SetActive(false);
    private void OpenPanel(GameObject panel, string sound)
    {
        panel.gameObject.SetActive(true);
        EventManager.Broadcast(GameEvent.OnPlaySound, sound);
    }
   
    public void Restart()
    {
        EventManager.Broadcast(GameEvent.OnPlaySound, "SoundClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
    





}