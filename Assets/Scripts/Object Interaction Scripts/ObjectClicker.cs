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
        if(Input.GetMouseButtonDown(0) )
        {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Interactable")))
                {
                    if (hit.transform != null && IsItemInRange(hit.transform))
                        CheckIfClickedOnCorrectGameObject(hit.transform.gameObject);
                }
        }
    }

    private bool IsItemInRange(Transform item)
    {
        return (Vector3.Distance(item.position, transform.position) < 1.2f) ? true : false;
    }

    private void CheckIfClickedOnCorrectGameObject(GameObject obj)
    {
        if(obj.tag == m_CorrectOrder[m_ItemsInEq].tag)
        {
            if (i_GameController.IsCountingStarted())
            {
                gameObject.GetComponent<PlayerMovement>().EquipItem(m_ItemsInEq++);
                obj.SetActive(false);
            }
            else
                MessageAnnouncer.Instance.ShowMessage("Nie ma potrzeby sie jeszcze ubierac");
        }
        else
            MessageAnnouncer.Instance.ShowMessage("Ubierasz sie w zlej kolejnosci");
    }
}
