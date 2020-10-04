using UnityEngine;

[CreateAssetMenu(menuName = "Game/MovementSettings", fileName = "New Movement Settings")]

public class MovementSettings : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 10f; //TODO: Move the static data to the Player Data
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private int _rotationRadius = 2;
    [SerializeField] private float _startRotationAngle = 90; //in degrees

    public float MoveSpeed
    {
        get => _moveSpeed;
        private set => _moveSpeed = value;
    }
    public float RotationSpeed
    {
        get => _rotationSpeed;
        private set => _rotationSpeed = value;
    }
    public int RotationRadius
    {
        get => _rotationRadius;
        private set => _rotationRadius = value;
    }
    public float StartRotationAngle
    {
        get => _startRotationAngle;
        private set => _startRotationAngle = value;
    }
}
