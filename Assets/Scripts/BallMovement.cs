using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public int switchScripts = 0;
    float moveSpeed = 5f;
    float rotateSpeed = 90f;
    float rotationRadius = 2f;
    float rotateAngle = 0f;
    
    Rigidbody m_Rigidbody;
    Transform m_Transform;

    Vector3 m_Movement;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Transform = GetComponent<Transform>();

    }


    void FixedUpdate()
    {
        EndlessMoveForward();

        RotateAroundCylinder();

        Debug.DrawLine(m_Rigidbody.position, Vector3.forward * m_Rigidbody.position.z, Color.red);
    }

    void EndlessMoveForward()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + (Vector3.forward * moveSpeed * Time.deltaTime));
    }

    void RotateAroundCylinder()
    {
        m_Transform.RotateAround(Vector3.zero, Vector3.forward, rotateAngle * rotateSpeed * Time.deltaTime);
    }
    void Movement(Rigidbody rb)
    {
        if(RotateDirection != 0)
        {
            Vector3 centerPos = Vector3.forward * rb.position.z;
            Vector3 gravityVector = centerPos - rb.position;
            Debug.Log("(rb.position = " + rb.position + " )");
            Vector3 newDirection = Vector3.Cross(gravityVector, Vector3.forward);
            Debug.Log("newDirection = " + newDirection);
            newDirection = newDirection.normalized;
            Debug.Log("newDirection normalized = " + newDirection);
            newDirection *= RotateDirection * rotationRadius;
            rb.velocity = newDirection;
            Debug.Log("velocity = " + rb.velocity);
        }
        
    }
    public float RotateDirection
    {
        get { return this.rotateAngle; }
        set { this.rotateAngle = value; }
    }
}
