using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_CharacterController;

    [SerializeField] [Range(1, 2)] private float m_MoveSpeed = 1f;

    private float m_CurrentSpeed;
    private float m_VerticalInput = 0f;
    private float m_HorizontalInput = 0f;

    private void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        HandleUserInput();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        m_CurrentSpeed = Mathf.Lerp( m_CurrentSpeed, 
                                    (m_VerticalInput != 0.0f && m_HorizontalInput != 0.0f)? 1.0f : 0.0f,
                                    Time.deltaTime * 4);
        Debug.Log(m_CurrentSpeed);
        m_CharacterController.Move(new Vector3( m_VerticalInput * m_CurrentSpeed *  m_MoveSpeed,
                                                0,
                                                m_HorizontalInput * m_CurrentSpeed * m_MoveSpeed) * Time.deltaTime * 2);
    }

    private void HandleUserInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_VerticalInput = 0.5f;
            m_HorizontalInput = -0.5f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_VerticalInput = -0.5f;
            m_HorizontalInput = 0.5f;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
            m_HorizontalInput = m_VerticalInput = -0.5f;
        else if (Input.GetKey(KeyCode.DownArrow))
            m_HorizontalInput = m_VerticalInput = 0.5f;
        else
            m_HorizontalInput = m_VerticalInput = 0.0f;
    }
}
