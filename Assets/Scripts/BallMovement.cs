using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Multiplier m_Multiplier;

    [SerializeField] public static float moveSpeed = 10f;
    float rotateSpeed = 90f;
    float rotationRadius = 2f;
    float rotationSpeed = 5f;
    float rotateDirection = 0f;
    float currAngle = (Mathf.PI/2) * Mathf.Rad2Deg;

    Rigidbody m_Rigidbody;
    public Transform m_Transform;

    Vector2 circlePosition;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        if (null == m_Transform)
            m_Transform = GetComponent<Transform>();
    }


    void FixedUpdate()
    {
        CirclePositionUpdate();
        MoveBall();

        Debug.DrawLine(m_Rigidbody.position, Vector3.forward * m_Rigidbody.position.z, Color.red);
        Debug.DrawLine(Vector3.up * 2, Vector3.forward * m_Rigidbody.position.z, Color.green);
    }

    void MoveBall()
    {
        Vector3 pos = new Vector3(
            circlePosition.x,
            circlePosition.y,
            m_Rigidbody.position.z + moveSpeed * m_Multiplier.multiplier * Time.deltaTime);
        m_Rigidbody.MovePosition(pos);

        float angle = Mathf.Acos(m_Rigidbody.position.x / rotationRadius) * Mathf.Rad2Deg;
        if (m_Rigidbody.position.y < 0) //invert angle for all negative Y positions
            angle = -angle;
        Quaternion rot = Quaternion.Euler(0f, 0f, angle - 90);
        m_Rigidbody.MoveRotation(rot);

    }

    private void CirclePositionUpdate()
    {
        currAngle += -RotateDirection * rotationSpeed * Time.deltaTime; 
        float x = Mathf.Cos(currAngle) * rotationRadius;
        float y = Mathf.Sin(currAngle) * rotationRadius;

        circlePosition = new Vector3(x, y, 0f);
    }
    void RotateAroundCylinder()
    {
        m_Transform.RotateAround(Vector3.zero, Vector3.forward, rotateDirection * rotateSpeed * Time.deltaTime);
    }
    public float RotateDirection
    {
        get { return this.rotateDirection; }
        set { this.rotateDirection = value; }
    }
}
