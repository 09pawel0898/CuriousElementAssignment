using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameplayController : MonoBehaviour
{
    [Inject]
    private GameController i_GameController;

    public static GameplayController Instance { get; private set; }

    public delegate void OnGameStartDelegate();
    public OnGameStartDelegate onGameStartDelegate;

    private AudioSource m_AudioSource;
    bool m_GameStarted = false;
    [SerializeField] private BarrelScript m_Barrel;

    public void StartTheGame()
    {
        i_GameController.Init();
        onGameStartDelegate?.Invoke();
        m_GameStarted = true;
    }

    private void Awake()
    {
        MakeInstance();
        m_AudioSource = GetComponent<AudioSource>();
    }

    private void MakeInstance()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        onGameStartDelegate += StartAnAllarm;
    }

    private void Update()
    {
        if (m_GameStarted)
            i_GameController.UpdateTimeCounter();
        if(i_GameController.FireExtinguished)
            StopTheGame();
    }
    
    private void StartAnAllarm()
    {
        StartCoroutine(StartAnAllarm(UnityEngine.Random.Range(3, 6)));
    }

    private IEnumerator StartAnAllarm(int secondsToStart)
    {
        yield return new WaitForSeconds(secondsToStart);
        m_AudioSource.Play();
        i_GameController.EnableTimeCounting();
        m_Barrel.ActivateFireSystem();
    }  

    private void StopTheGame()
    {
        m_AudioSource.Stop();
        Time.timeScale = 0.0f;
    }
}
