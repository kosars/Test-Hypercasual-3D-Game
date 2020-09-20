using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    public GameObject hooverCollector;
    float fieldForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce((hooverCollector.transform.position - transform.position) * fieldForce * Time.smoothDeltaTime);
    }
}
