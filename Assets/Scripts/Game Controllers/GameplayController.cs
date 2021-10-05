using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance { get; private set; }

    public delegate void OnGameStartDelegate();
    public OnGameStartDelegate onGameStartDelegate;
    private AudioSource m_AudioSource;

    public void StartTheGame()
    {
        GameplayController.Instance.onGameStartDelegate?.Invoke();
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
    }
    
    private void StartAnAllarm()
    {
        StartCoroutine(StartAnAllarm(UnityEngine.Random.Range(3, 6)));
    }

    public IEnumerator StartAnAllarm(int secondsToStart)
    {
        yield return new WaitForSeconds(secondsToStart);
        m_AudioSource.Play();
    }
}
