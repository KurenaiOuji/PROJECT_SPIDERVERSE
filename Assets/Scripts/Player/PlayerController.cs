using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;

    [Header("Movement Settings")]
    [SerializeField] private float _Speed = 5f;

    [Header("Inputs")]
    private float _HorizontalInput;
    private float _VerticalInput;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        InputManagement();
        Movement();
    }

    private void Movement()
    {
        GroundMovement();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3 (_HorizontalInput, -9.81f, _VerticalInput);

        move *= _Speed;

        _controller.Move(move * Time.deltaTime);
    }

    private void InputManagement()
    {
        _HorizontalInput = Input.GetAxis("Horizontal");
        _VerticalInput = Input.GetAxis("Vertical");
    }
}
