using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerMultiplier _multiplier;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MovementSettings _movementSettings;

    public static float MoveSpeed { get; private set; }

    public static float RotationSpeed { get; private set; }

    public static int RotationRadius { get; private set; }

    public static float CurrentAngle { get; private set; }


    private void Awake()
    {
        MoveSpeed = _movementSettings.MoveSpeed;
        RotationSpeed = _movementSettings.RotationSpeed;
        RotationRadius = _movementSettings.RotationRadius;
        CurrentAngle = _movementSettings.StartRotationAngle;
    }

    public void MoveSpiral(float rotateDirection)
    {
        Vector3 circlePosition = UpdateSpiralPosition(rotateDirection);

        Vector3 pos = new Vector3(
            circlePosition.x,
            circlePosition.y,
            _rigidbody.position.z + MoveSpeed * _multiplier.SpeedMultiplier * Time.deltaTime);
        _rigidbody.MovePosition(pos);

        float angle = Mathf.Acos(_rigidbody.position.x / RotationRadius) * Mathf.Rad2Deg;
        if (_rigidbody.position.y < 0) //invert angle for all negative Y positions
            angle = -angle;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle - 90);
        _rigidbody.MoveRotation(rot);

    }
   
    private Vector3 UpdateSpiralPosition(float rotateDirection)
    {
        CurrentAngle += -rotateDirection * RotationSpeed * Time.deltaTime;
        float x = Mathf.Cos(CurrentAngle * Mathf.PI / 180F) * RotationRadius;
        float y = Mathf.Sin(CurrentAngle * Mathf.PI / 180F) * RotationRadius;

        return new Vector3(x, y, 0f);
    }
}
