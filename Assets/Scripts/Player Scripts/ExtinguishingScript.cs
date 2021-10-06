using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtinguishingScript : MonoBehaviour
{
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();    
    }

    private void Update()
    {
        if(m_Animator.GetBool("Extinguish"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position,transform.forward.normalized, out hit, 0.7f, LayerMask.GetMask("Extinguishable")))
            {
                if (hit.transform != null)
                    CheckIfThereIsSthToExtinguish(hit.transform.gameObject);
            }
        }
    }

    private void CheckIfThereIsSthToExtinguish(GameObject obj)
    {
        if(obj.tag == "Barrel")
        {
            obj.GetComponent<BarrelScript>().UpdateFireStatus();
        }
    }
}
