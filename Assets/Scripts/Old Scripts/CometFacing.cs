using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometFacing : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    float moveSpeed = BallMovement.moveSpeed;
    float angle;
    float radius = 2f;
    Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        Transform t = GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
        angle = transform.rotation.z;
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        movementVector = new Vector3(x,y,0f);
        t.position -= movementVector*moveSpeed;
        movementVector.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + movementVector * moveSpeed * Time.deltaTime);
    }
}
