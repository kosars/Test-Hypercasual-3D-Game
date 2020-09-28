using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static event Action OnPlayerHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CometRotation>() != null
           || collision.gameObject.GetComponent<CometFacing>() != null)
        {
            OnPlayerHit?.Invoke();
        }

    }
}
