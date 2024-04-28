using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private InputActionReference _move;

    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _speed;
    private float _runningSpeed;
    private Animator _animator = null;
    private bool _freezed = false;
    public bool Freezed { get => _freezed; }

    private bool currentChosenDirection; //true=x, false=y
    private bool isInDoubleDirection;

    private void Start()
    {
        _runningSpeed = _speed;
        _animator = GetComponentInChildren<Animator>();
        Freeze();
    }

    private void Update()
    {
        _direction = _move.action.ReadValue<Vector2>();

        if (_direction.x != 0f && _direction.y != 0f)
        {
            if (!isInDoubleDirection)
                isInDoubleDirection = true;

            _direction = new Vector2(
                currentChosenDirection ? _direction.x : 0f,
                !currentChosenDirection ? _direction.y : 0f
                );
        }
        else 
        {
            isInDoubleDirection = false;
            currentChosenDirection = _direction.x == 0f;
        }

        _rb.velocity = _direction * _runningSpeed;

        _animator.SetFloat("Horizontal", _rb.velocity.x);
        _animator.SetFloat("Vertical", _rb.velocity.y);
    }

    public void Freeze()
    {
        _runningSpeed = 0f;
        _freezed = true;
    }

    public void UnFreeze()
    {
        _runningSpeed =_speed;
        _freezed = false;
    }
}
