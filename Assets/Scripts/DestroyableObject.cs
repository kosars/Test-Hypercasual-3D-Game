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
    private float delayBeforeMove = 1f;

    private void Start()
    {
        if (null == colletor)
            colletor = GameObject.Find("BlowingPoint").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (!isTriggered)
            return;
        if ((double)delayBeforeMove > 0.0)
        {
            delayBeforeMove -= Time.deltaTime;
        }
        else
        {
            if ((double)selfDestroyTimer < 0.0)
                Object.Destroy((Object)gameObject);
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
        if ((Object)null == (Object)obj)
            return;
        foreach (Transform transform in obj.transform)
        {
            if ((Object)null == (Object)transform)
                break;
            if ((bool)(Object)transform.gameObject.GetComponent<Rigidbody>())
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
            if (!((Object)null == (Object)rigidbody))
            {
                Vector3 position = Vector3.MoveTowards(rigidbody.position, colletor.position, 10f * Time.deltaTime);
                rigidbody.MovePosition(position);
            }
        }
    }

    private void MoveChildRecursive(GameObject obj)
    {
        if ((Object)null == (Object)obj)
            return;
        foreach (Transform transform in obj.transform)
        {
            if (!((Object)null == (Object)transform))
            {
                Rigidbody component;
                if (transform.gameObject.TryGetComponent<Rigidbody>(out component))
                {
                    component.isKinematic = true;
                    Vector3 position = Vector3.MoveTowards(component.position, colletor.position, 10f * Time.deltaTime);
                    component.MovePosition(position);
                }
                MoveChildRecursive(transform.gameObject);
            }
        }
    }
}
