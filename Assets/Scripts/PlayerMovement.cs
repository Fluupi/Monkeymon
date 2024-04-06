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

    private void Update()
    {
        _direction = _move.action.ReadValue<Vector2>();

        if (Mathf.Abs(_direction.x) == Mathf.Abs(_direction.y))
            return;

        Debug.Log("moving");
        
        _rb.MovePosition(_rb.position + _direction * Time.deltaTime * _speed);
    }
}
