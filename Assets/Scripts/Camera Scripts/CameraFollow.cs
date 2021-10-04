using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform m_Target;
    private float m_FollowingSpeed = 3.0f;
    private Vector3 m_CameraOffset;

    private void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); // i am using build-in player tag
    }

    private void Start()
    {
        m_CameraOffset = transform.position - m_Target.position;
    }

    private void Update()
    {
        transform.position = Vector3.Slerp( transform.position,
                                            new Vector3(m_Target.position.x, 0, m_Target.position.z) + m_CameraOffset,
                                            Time.deltaTime * m_FollowingSpeed);
    }
}
