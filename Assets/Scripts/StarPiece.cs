using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPiece : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 movePoint;

    [SerializeField] private Rigidbody m_Rigidbody;

    private void Start()
    {
        if (null == m_Rigidbody)
            m_Rigidbody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate() => MoveToPos();

    private void MoveToPos()
    {
        if (movePoint == m_Rigidbody.position)
        {
            this.m_Rigidbody.velocity = Vector3.zero;
            this.enabled = false;
        }
        Vector3 direction = Vector3.MoveTowards(this.m_Rigidbody.position, this.movePoint, this.moveSpeed * Time.deltaTime);
        m_Rigidbody.MovePosition(direction);
    }

    public Vector3 moveTo
    {
        get => this.movePoint;
        set => this.movePoint = value;
    }
}
