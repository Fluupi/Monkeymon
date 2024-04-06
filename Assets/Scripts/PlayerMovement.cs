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

    private void Start()
    {
        _runningSpeed = _speed;
        _animator = GetComponentInChildren<Animator>();
        Freeze();
    }

    private void Update()
    {
        _direction = _move.action.ReadValue<Vector2>();

        if (Mathf.Abs(_direction.x) == Mathf.Abs(_direction.y))
        {
            _direction = Vector2.zero;
        }

        _rb.velocity = _direction * _runningSpeed;

        if (_direction.sqrMagnitude > 0.0f)
        {
            Debug.Log("moving");
        }
        _animator.SetFloat("Horizontal", _rb.velocity.x);
        _animator.SetFloat("Vertical", _rb.velocity.y);
    }

    public void Freeze()
    {
        _runningSpeed = 0f;
    }

    public void UnFreeze()
    {
        _runningSpeed =_speed;
    }
}
