using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController
{
    private Text m_TimeText;
    private float m_GameStartTime;
    private bool m_CountingActive = false;

    public GameController()
    {}
    
    public void UpdateTimeCounter()
    {
        if(m_CountingActive)
            m_TimeText.text = "Time : " + Math.Round(Time.realtimeSinceStartup - m_GameStartTime,2).ToString();
    }

    public void Init()
    {
        InitGameStartDelegate();
    }

    private void InitGameStartDelegate()
    {
        GameplayController.Instance.onGameStartDelegate += EnablePlayerMovementScript;
    }

    private void EnablePlayerMovementScript()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
    }
    public void EnableTimeCounting()
    {
        m_TimeText = GameObject.FindWithTag("TimeText").GetComponent<Text>();
        m_TimeText.enabled = true;
        m_GameStartTime = Time.realtimeSinceStartup;
        m_CountingActive = true;
    }

    public bool IsCountingStarted()
    {
        return m_CountingActive;
    }
}
