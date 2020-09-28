using System;
using UnityEngine;

public class PlayerMultiplier : MonoBehaviour
{
    public static event Action OnSpeedUp; //TODO OnSpeedUpUI

    private float _multiplier = 1f; //TODO: MultiplierUI
    private float _speedMultiplier = 1f; 

    public float Multiplier
    {
        get => _multiplier;
        set
        {
            _multiplier = value;
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
        PlayerCollision.OnPlayerHit += () => HandleHit();

    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= () => HandleHit();
    }

    private void HandleHit()
    {
        Multiplier = 1f; // decrease Multiplier to start value
    }
}
