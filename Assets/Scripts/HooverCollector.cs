using UnityEngine;

public class HooverCollector : MonoBehaviour
{
    private void OnEnable() => LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    private void OnDisable() => LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag != "NotDestroy"))
            return;
        Destroy(other.gameObject);
    }

    private void HandleLevelComplete() => this.enabled = false;
}