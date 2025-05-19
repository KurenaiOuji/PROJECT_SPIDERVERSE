using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    private CharacterController _controller;
    [SerializeField] private Transform _camera;

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _turningSpeed = 2f;

    [Header("Inputs")]
    private float _horizontalInput;
    private float _verticalInput;

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
        Turn();
    }

    private void GroundMovement()
    {
        Vector3 move = new Vector3 (_horizontalInput, -9.81f, _verticalInput);
        move = transform.TransformDirection(move);

        move *= _speed;

        _controller.Move(move * Time.deltaTime);
    }

    private void Turn()
    {
        if (Mathf.Abs(_horizontalInput) > 0 || Mathf.Abs(_verticalInput) > 0)
        {
            Vector3 currentLookDirection = _camera.forward;
            currentLookDirection.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(currentLookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _turningSpeed);
        }
    }

    private void InputManagement()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }
}
