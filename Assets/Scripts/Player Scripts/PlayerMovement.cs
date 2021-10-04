using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum FacingDirection
{
    Left,Right,Up,Down
}

public class PlayerMovement : MonoBehaviour
{
    private FacingDirection m_FacingDirection;
    private Dictionary<FacingDirection, float> m_ModelRotations;
    private CharacterController m_CharacterController;
    private Animator m_Animator;
    private Transform m_Transform;

    [SerializeField] [Range(1, 2)] private float m_MoveSpeed = 1f;

    private float m_CurrentSpeed;
    private float m_VerticalInput = 0f;
    private float m_HorizontalInput = 0f;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        m_CharacterController = GetComponent<CharacterController>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        m_FacingDirection = FacingDirection.Up;
        InitRotations();
    }

    private void InitRotations()
    {
        m_ModelRotations = new Dictionary<FacingDirection, float>();
        m_ModelRotations.Add(FacingDirection.Left, 135);
        m_ModelRotations.Add(FacingDirection.Right, 315);
        m_ModelRotations.Add(FacingDirection.Up, 225);
        m_ModelRotations.Add(FacingDirection.Down, 45);
    }

    private void Update()
    {
        HandleUserInput();
        UpdateFacingDirection();
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        m_CurrentSpeed = Mathf.Lerp( m_CurrentSpeed, 
                                    (m_VerticalInput != 0.0f && m_HorizontalInput != 0.0f)? 1.0f : 0.0f,
                                    Time.deltaTime * 4);

        m_CharacterController.Move(new Vector3( m_VerticalInput * m_CurrentSpeed *  m_MoveSpeed,
                                                0,
                                                m_HorizontalInput * m_CurrentSpeed * m_MoveSpeed) * Time.deltaTime * 2);
    }

    private void UpdateFacingDirection()
    {
        m_Transform.rotation = Quaternion.Euler(0.0f, m_ModelRotations[m_FacingDirection], 0.0f);
    }

    private void HandleUserInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            m_VerticalInput = 0.5f;
            m_HorizontalInput = -0.5f;
            m_FacingDirection = FacingDirection.Left;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_VerticalInput = -0.5f;
            m_HorizontalInput = 0.5f;
            m_FacingDirection = FacingDirection.Right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            m_HorizontalInput = m_VerticalInput = -0.5f;
            m_FacingDirection = FacingDirection.Up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_HorizontalInput = m_VerticalInput = 0.5f;
            m_FacingDirection = FacingDirection.Down;
        }
        else
        {
            m_HorizontalInput = m_VerticalInput = 0.0f;
            m_Animator.SetBool("Walk", false);
            return;
        }
        m_Animator.SetBool("Walk", true);
    }
}
