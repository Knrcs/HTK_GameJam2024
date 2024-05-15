using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 20f;
    public float sizeMultiplier;
    private Vector2 _lastVelocity;
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
        _lastVelocity = _rigidbody2D.velocity;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _movementInput * runSpeed;

        if (_rigidbody2D.velocity != _lastVelocity)
        {
            if (_rigidbody2D.velocity.y < 0 && transform.localScale.y < 3.0f)
            {
                transform.localScale *= sizeMultiplier;
            }
            else if (_rigidbody2D.velocity.y > 0 && transform.localScale.y > 1.0f)
            {
                transform.localScale /= sizeMultiplier;
            }
        }
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }
}
