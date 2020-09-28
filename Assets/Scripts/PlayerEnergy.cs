using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public static event Action OnFullEnergyLost;
    public static event Action<float> OnEnergyChange;

    private float _currentEnergy = 1f;
    private float _currentMaxEnergy = 1f; //TODO Make all data get from the ScriptableObject
    private float _energyLostPerSec = 0.25f;

    public float Energy
    {
        get => _currentEnergy;
        set
        {
            _currentEnergy = value;
            OnEnergyChange?.Invoke(value);
            if (value <= 0)
            {
                OnFullEnergyLost?.Invoke();
            }
        }
    }

    void FixedUpdate()
    {
        Energy -= _energyLostPerSec * Time.deltaTime;
    }

    //TODO UpEnergy PlayerCollision.OnDestroyableObjectCollect
    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += () => HandleHit();
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= () => HandleHit();
    }

    public void UpEnergy(float value)
    {
        if (Energy + value > _currentMaxEnergy)
            Energy = _currentMaxEnergy;
        else
            Energy += value;
    }

    public void DownEnergy(float value)
    {
        if (Energy - value < 0)
            Energy = 0f;
        else
            Energy -= value;
    }

    private void HandleHit()
    {
        DownEnergy(0.5f);
    }

    private void HandleDestroyableObjectCollect()
    {
        UpEnergy(0.25f);
    }
}
