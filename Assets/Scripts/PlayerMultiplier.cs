using System;
using UnityEngine;

public class PlayerMultiplier : MonoBehaviour
{
    public static event Action<float> OnMultiplierChange;
    public static event Action OnSpeedUp; 

    private float _multiplier = 1f;
    private float _speedMultiplier = 1f; 

    public float Multiplier
    {
        get => _multiplier;
        set
        {
            _multiplier = value;
            OnMultiplierChange?.Invoke(value);
            SpeedMultiplier = value;
        }
    }

    public float SpeedMultiplier
    {
        get => _speedMultiplier;
        private set
        {
            float prev = _speedMultiplier;
            _speedMultiplier = (value - ((value) % 0.5f)); //speed multipluer always multiple of 0.5

            if (_speedMultiplier > prev)
                OnSpeedUp?.Invoke();
        }
    }

    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += HandleHit;
        DestroyableObjectTrigger.OnDestroyableObjectCollect += HandleDestroyableObjectCollect;
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= HandleHit;
        DestroyableObjectTrigger.OnDestroyableObjectCollect -= HandleDestroyableObjectCollect;
    }

    private void HandleHit()
    {
        Multiplier = 1f; // decrease Multiplier to start value
    }

    private void HandleDestroyableObjectCollect()
    {
        Multiplier += 0.1f; // increase multiplier (0.1 per 1 object)
    }
}
