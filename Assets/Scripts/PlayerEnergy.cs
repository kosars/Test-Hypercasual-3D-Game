using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    public static event Action OnFullEnergyLost;
    public static event Action<float> OnEnergyChange;

    [SerializeField] private EnergySettings _energySettings;

    private float _currentEnergy;
    private float _currentMaxEnergy;
    private float _energyLostPerSec;

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

    private void Awake()
    {
        _currentMaxEnergy = _energySettings.MaxEnergy;
        _currentEnergy = _currentMaxEnergy;
        _energyLostPerSec = _energySettings.EnergyLostPerSec;
    }

    void FixedUpdate() => Energy -= _energyLostPerSec * Time.deltaTime; 

    private void OnEnable()
    {
        PlayerCollision.OnPlayerHit += HandleHit;
        DestroyableObjectTrigger.OnDestroyableObjectCollect += HandleDestroyableObjectCollect;
        LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    }

    private void OnDisable()
    {
        PlayerCollision.OnPlayerHit -= HandleHit;
        DestroyableObjectTrigger.OnDestroyableObjectCollect -= HandleDestroyableObjectCollect;
        LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;

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

    private void HandleHit() => DownEnergy(0.5f);

    private void HandleDestroyableObjectCollect() => UpEnergy(0.25f);

    private void HandleLevelComplete() => this.enabled = false;
}
