using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometRotation : MonoBehaviour
{ 
    float rotationRadius = 2f;
    float rotationSpeed = 1f;
    float rotateDirection = 1f;
    float currAngle;

    Rigidbody m_Rigidbody;
    Vector2 circlePosition;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

        currAngle = GetAngleByX();
    }


    void FixedUpdate()
    {
        CirclePositionUpdate();
        MoveBall();
    }

    void MoveBall()
    {
        Vector3 pos = new Vector3(
            circlePosition.x,
            circlePosition.y,
            m_Rigidbody.position.z);
        m_Rigidbody.MovePosition(pos);

        float angle = GetAngleByX();
        Quaternion rot = Quaternion.Euler(0f, 0f, angle - 90);
        m_Rigidbody.MoveRotation(rot);

    }
    private void CirclePositionUpdate()
    {
        currAngle += rotateDirection * rotationSpeed * Time.deltaTime; 
        float x = Mathf.Cos(currAngle) * rotationRadius;
        float y = Mathf.Sin(currAngle) * rotationRadius;

        circlePosition = new Vector3(x, y, 0f);
    }

    private float GetAngleByX()
    {
        float a = Mathf.Acos(m_Rigidbody.position.x / rotationRadius) * Mathf.Rad2Deg;
        if (m_Rigidbody.position.y < 0) //invert angle for all negative Y positions
            a = -a;
        return a;
    }
    public float RotateDirection
    {
        get { return this.rotateDirection; }
        set { this.rotateDirection = value; }
    }
}
