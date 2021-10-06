using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private InputField m_NameInput;

    private void Awake()
    {}

    public void StartTheGame()
    {
        if (IsNameEntered())
        {
            Destroy(gameObject);
            GameplayController.Instance.StartTheGame();
        }
    }

    bool IsNameEntered()
    {
        return (m_NameInput.text != "")? true : false;
    }
}
