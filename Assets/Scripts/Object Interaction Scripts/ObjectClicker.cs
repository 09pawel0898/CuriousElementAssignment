using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField] private GameObject[] m_CorrectOrder;
    [Inject] private GameController i_GameController;

    private int m_ItemsInEq = 0;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && i_GameController.IsCountingStarted())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, 100.0f,LayerMask.GetMask("Interactable")))
            {
                if(hit.transform != null)
                {
                    CheckIfClickedOnCorrectGameObject(hit.transform.gameObject);
                }    
            }
        }
    }

    private void CheckIfClickedOnCorrectGameObject(GameObject obj)
    {
        if(obj.tag == m_CorrectOrder[m_ItemsInEq].tag)
        {
            gameObject.GetComponent<PlayerMovement>().EquipItem(m_ItemsInEq++);
            obj.SetActive(false);
        }
        else
        {
            // wrong order
            Debug.Log("Wrong order");
        }
    }
}
