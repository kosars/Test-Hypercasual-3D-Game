using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMultiplier _multiplier; 
    [SerializeField] private Rigidbody _rigidbody;

    public static float _moveSpeed = 10f; //TODO: Move the static data to the Player Data
    public static float _rotationSpeed = 5f;
    public static float _rotationRadius = 2f;
    float _currAngle = (Mathf.PI / 2) * Mathf.Rad2Deg;

    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += HandleFullEnergyLost;
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= HandleFullEnergyLost;
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

    private void HandleFullEnergyLost()
    {
        this.enabled = false; //if we have no energy than we cannot move
    }
}
