using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/EnergySettings", fileName = "New Energy Settings")]

public class EnergySettings : ScriptableObject
{
    [SerializeField] private float _currentMaxEnergy = 1f;
    [SerializeField] private float _energyLostPerSec = 0.2f;

    public float MaxEnergy {
        get => _currentMaxEnergy;
        private set => _currentMaxEnergy = value;
    }

    public float EnergyLostPerSec
    {
        get => _energyLostPerSec;
        private set => _energyLostPerSec = value;
    }
}
