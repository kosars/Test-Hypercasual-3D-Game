using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform _collectorTransform;
    [SerializeField] private List<Rigidbody> _childrensRigidbodies;

    //TODO: MAKE FROM SCRIPTABLEOBJECT
    private float _selfDestroyTimer = 15f;
    private float _delayBeforeMove = 1f / (PlayerMovement.MoveSpeed / 5f); // (1 second / (player.moveSpeed/5f))
    private float _moveSpeed = 10f * (PlayerMovement.MoveSpeed / 5f);

    private void Awake()
    {
        if (null == _collectorTransform)
            _collectorTransform = GameObject.Find("Collector").transform;
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
            MoveList(_childrensRigidbodies);
            _selfDestroyTimer -= Time.deltaTime;
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
}
