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
            m_TimeText.text = "Czas : " + Math.Round(Time.realtimeSinceStartup - m_GameStartTime,2).ToString();
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

    private void DisablePlayerMovementScript()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
    }

    public void EnableTimeCounting()
    {
        m_TimeText = GameObject.FindWithTag("TimeText").GetComponent<Text>();
        m_TimeText.enabled = true;
        m_GameStartTime = Time.realtimeSinceStartup;
        m_CountingActive = true;
    }

    public void StopCountingAndShowFinalTime()
    {
        DisablePlayerMovementScript();
        m_CountingActive = false;
        string time = m_TimeText.text.Substring(6);
        MessageAnnouncer.Instance.ShowMessage("Sukces! Twoj koncowy czas to : " + time,false);
        Time.timeScale = 0.0f;
        m_TimeText.enabled = false;
    }

    public bool IsCountingStarted()
    {
        return m_CountingActive;
    }
}
