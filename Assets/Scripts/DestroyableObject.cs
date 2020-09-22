using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    [SerializeField]
    private Transform colletor;
    [SerializeField]
    private List<Rigidbody> rbChildrens = new List<Rigidbody>();

    private bool isTriggered;
    private float selfDestroyTimer = 15f;
    private float delayBeforeMove = 1f / (BallMovement.moveSpeed / 5f); // (1 second / (player.moveSpeed/5f))
    private float moveSpeed = 10f * (BallMovement.moveSpeed / 5f);

    private void Start()
    {
        if (null == colletor)
            colletor = GameObject.Find("BlowingPoint").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (!isTriggered)
            return;
        if (delayBeforeMove > 0.0)
        {
            delayBeforeMove -= Time.deltaTime;
        }
        else
        {
            if (selfDestroyTimer < 0.0)
                Destroy(gameObject);
            MoveChildRecursive(gameObject);
            selfDestroyTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name == "Ball"))
            return;
        isTriggered = true;
    }

    private void CollectChildRBRecursive(GameObject obj)
    {
        if (null == obj)
            return;
        foreach (Transform transform in obj.transform)
        {
            if (null == transform)
                break;
            if (transform.gameObject.GetComponent<Rigidbody>())
                rbChildrens.Add(transform.gameObject.GetComponent<Rigidbody>());
            CollectChildRBRecursive(transform.gameObject);
        }
    }

    private void MoveList(List<Rigidbody> list)
    {
        if (list == null)
            return;
        foreach (Rigidbody rigidbody in list)
        {
            if (!(null == rigidbody))
            {
                Vector3 position = Vector3.MoveTowards(rigidbody.position, colletor.position, moveSpeed * Time.deltaTime);
                rigidbody.MovePosition(position);
            }
        }
    }

    private void MoveChildRecursive(GameObject obj)
    {
        if (null == obj)
            return;
        foreach (Transform transform in obj.transform)
        {
            if (!(null == transform))
            {
                Rigidbody component;
                if (transform.gameObject.TryGetComponent<Rigidbody>(out component))
                {
                    component.isKinematic = true;
                    Vector3 position = Vector3.MoveTowards(component.position, colletor.position, moveSpeed * Time.deltaTime);
                    component.MovePosition(position);
                }
                MoveChildRecursive(transform.gameObject);
            }
        }
    }
}
