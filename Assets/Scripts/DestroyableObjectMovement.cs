using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform _collectorTransform;
    [SerializeField] private List<Rigidbody> _childrensRigidbodies = new List<Rigidbody>(); //TODO: MAKE FROM INSPECTOR


    private float _selfDestroyTimer = 15f;
    //TODO: Свойства в PlayerMovement
    private float _delayBeforeMove = 1f / (PlayerMovement._moveSpeed / 5f); // (1 second / (player.moveSpeed/5f))
    private float _moveSpeed = 10f * (PlayerMovement._moveSpeed / 5f);

    private void Awake()
    {
        CollectChildRBRecursive(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (_delayBeforeMove > 0.0)
        {
            _delayBeforeMove -= Time.deltaTime;
        }
        else
        {
            if (_selfDestroyTimer < 0.0)
                Destroy(gameObject); //TODO: TRY WITH DEACTIVATING OF GAMEOBJECT
            MoveChildRecursive(gameObject); //TODO: MOVE LIST FROM INSPECTOR BUT NOT CHILDS
            _selfDestroyTimer -= Time.deltaTime;
        }
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
                _childrensRigidbodies.Add(transform.gameObject.GetComponent<Rigidbody>());
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
                Vector3 position = Vector3.MoveTowards(rigidbody.position, _collectorTransform.position, _moveSpeed * Time.deltaTime);
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
                    Vector3 position = Vector3.MoveTowards(component.position, _collectorTransform.position, _moveSpeed * Time.deltaTime);
                    component.MovePosition(position);
                }
                MoveChildRecursive(transform.gameObject);
            }
        }
    }
}
