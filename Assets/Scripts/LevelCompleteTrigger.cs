using System;
using UnityEngine;
using UnityEngine.Events;


public class LevelCompleteTrigger : MonoBehaviour
{
    public static event Action OnLevelComplete;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name == "Ball"))
            return;
        OnLevelComplete?.Invoke();

        //TODO: SPAWN STARS
        //TODO: MOVE CAMERA
    }
}
