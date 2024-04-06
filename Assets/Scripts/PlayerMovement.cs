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

    private void Start()
    {
        _runningSpeed = _speed;
    }

    private void Update()
    {
        _direction = _move.action.ReadValue<Vector2>();

        if (_runningSpeed == 0f || Mathf.Abs(_direction.x) == Mathf.Abs(_direction.y))
            return;

        Debug.Log("moving");
        
        _rb.MovePosition(_rb.position + _direction * Time.deltaTime * _runningSpeed);
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
