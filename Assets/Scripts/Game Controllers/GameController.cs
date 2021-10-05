using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    public GameController()
    {
        InitGameStartDelegate();
    }

    private void InitGameStartDelegate()
    {
        GameplayController.Instance.onGameStartDelegate += EnablePlayerMovementScript;
    }

    private void EnablePlayerMovementScript()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gameObject.SetActive(true);
    }
}
