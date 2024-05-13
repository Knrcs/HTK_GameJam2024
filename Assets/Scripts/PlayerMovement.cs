using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 20f;
    private float _playerMovementDirection = 0;
    private Rigidbody2D _rigidbody2D;
    private PlayerControls _inputAction;
    private Vector2 _movementInput;


    private void Start()
    {
        _rigidbody2D ??= GetComponent<Rigidbody2D>();
        _inputAction = new PlayerControls();
        _inputAction.Enable();
        _inputAction.Player.Move.performed += moving =>
        {
            _playerMovementDirection = moving.ReadValue<float>();
        };
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movementInput * runSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
