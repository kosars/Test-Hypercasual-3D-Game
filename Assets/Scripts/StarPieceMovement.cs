using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPieceMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _moveSpeed = 5f;
    private Vector3 _movePoint;
    public Vector3 MoveTo
    {
        get => _movePoint;
        set => _movePoint = value;
    }

    private void Awake()
    {
        if (null == _rigidbody)
            _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() => MoveToPos(_movePoint);

    private void MoveToPos(Vector3 pos)
    {
        if (_movePoint == _rigidbody.position)
        {
            _rigidbody.velocity = Vector3.zero;
            enabled = false;
        }
        Vector3 direction = Vector3.MoveTowards(_rigidbody.position, pos, _moveSpeed * Time.deltaTime);
        _rigidbody.MovePosition(direction);
    }

}
