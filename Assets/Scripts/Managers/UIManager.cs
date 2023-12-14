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
    [SerializeField] private TMP_Text playerCoinText;
    [SerializeField] private TMP_Text playerKillText;


    //[Space(15)]
    //[Header("Arrays")]


    //[Space(15)]
    //[Header("Float&Int")]


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameData = gameManager.gameData;
        SetGameInfoUI();

    }

    private void OnEnable()
    {
       
        EventManager.AddHandler(GameEvent.OnFail, OnFail);
        EventManager.AddHandler(GameEvent.OnStart, OnStart);
        EventManager.AddHandler(GameEvent.OnCollectCoin, OnCollectCoin);
    }
    private void OnDisable()
    {
        
        EventManager.RemoveHandler(GameEvent.OnFail, OnFail);
        EventManager.RemoveHandler(GameEvent.OnStart, OnStart);
        EventManager.RemoveHandler(GameEvent.OnCollectCoin, OnCollectCoin);
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
        //EventManager.Broadcast(GameEvent.OnPlaySound, sound);
    }
   
    public void Restart()
    {
        //EventManager.Broadcast(GameEvent.OnPlaySound, "SoundClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnCollectCoin()
    {
        Debug.Log("OnCollectCoin"+gameData.playerCoin);
        playerCoinText.text=gameData.playerCoin.ToString();

    }

    void SetGameInfoUI()
    {
        playerCoinText.text = GameManager.Instance.gameData.playerCoin.ToString();
        playerKillText.text = GameManager.Instance.gameData.playerKill.ToString();

    }
   
    





}