using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnEnable() => LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    private void OnDisable() => LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;

    private void HandleLevelComplete() => this.gameObject.SetActive(false);
    private void OnTriggerEnter(Collider other) => Destroy(other.gameObject);
}
