using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) => Object.Destroy((Object)other.gameObject);
}
