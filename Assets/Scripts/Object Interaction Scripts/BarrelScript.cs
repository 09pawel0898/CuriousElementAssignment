using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BarrelScript : MonoBehaviour
{
    [Inject] private GameController i_GameController;
    [SerializeField] private GameObject m_FireSystem;
    [SerializeField] private float m_FireIntensity = 1000;

    private void Start()
    {}

    public void ActivateFireSystem()
    {
        m_FireSystem.SetActive(true);
    }

    public void DeactivateFireSystem()
    {
        m_FireSystem.SetActive(false);
    }

    public void UpdateFireStatus()
    {
        if (--m_FireIntensity == 0)
        {
            DeactivateFireSystem();
            i_GameController.StopCountingAndShowFinalTime();
        }
    }
}
