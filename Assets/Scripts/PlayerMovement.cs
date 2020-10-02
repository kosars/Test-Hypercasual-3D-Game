using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMultiplier _multiplier; 
    [SerializeField] private Rigidbody _rigidbody;

    private static float _moveSpeed = 10f; //TODO: Move the static data to the Player Data
    private static float _rotationSpeed = 5f;
    private static float _rotationRadius = 2f;
    private float _currAngle = (Mathf.PI / 2) * Mathf.Rad2Deg;

    public static float MoveSpeed
    {
        get => _moveSpeed;
        private set => _moveSpeed = value;
    }

    public static float RotationSpeed
    {
        get => _rotationSpeed;
        private set => _rotationSpeed = value;
    }

    public static float RotationRadius
    {
        get => _rotationRadius;
        private set => _rotationRadius = value;
    }

    public void MoveSpiral(float rotateDirection)
    {
        Vector3 circlePosition = UpdateSpiralPosition(rotateDirection);

        Vector3 pos = new Vector3(
            circlePosition.x,
            circlePosition.y,
            _rigidbody.position.z + _moveSpeed * _multiplier.SpeedMultiplier * Time.deltaTime);
        _rigidbody.MovePosition(pos);

        float angle = Mathf.Acos(_rigidbody.position.x / _rotationRadius) * Mathf.Rad2Deg;
        if (_rigidbody.position.y < 0) //invert angle for all negative Y positions
            angle = -angle;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle - 90);
        _rigidbody.MoveRotation(rot);

    }

    private Vector3 UpdateSpiralPosition(float rotateDirection)
    {
        _currAngle += -rotateDirection * _rotationSpeed * Time.deltaTime;
        float x = Mathf.Cos(_currAngle) * _rotationRadius;
        float y = Mathf.Sin(_currAngle) * _rotationRadius;

        return new Vector3(x, y, 0f);
    }
}
