using UnityEngine;

public class HooverCollector : MonoBehaviour
{
    private static int itemsDestroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag != "NotDestroy"))
            return;
        Destroy(other.gameObject);
        ++itemsDestroyed;
    }
}