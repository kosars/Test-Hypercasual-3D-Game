using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //TODO: ChangeScoreLogic
    public static event Action<int> OnScoreChange;
    [SerializeField] private PlayerMultiplier _multiplier;

    //TODO: PlayerSoreUI
    private static int _currentScore;
    private static int _deltaScore;
    private static int _targetScore;

    public static int CurrentScore
    {
        get => _currentScore;
        private set
        {
            DeltaScore = value - CurrentScore;
            _currentScore = value;
            OnScoreChange.Invoke(value);
        }
    }
    public static int TargetScore
    {
        get => _targetScore;
        set => _targetScore = value;
    }
    public static int DeltaScore
    {
        get => _deltaScore;
        private set => _deltaScore = value;
    }

    public void AddScore(int value)
    {
        CurrentScore += (int)(value * _multiplier.Multiplier);
    }

    private void OnEnable()
    {
        DestroyableObjectTrigger.OnDestroyableObjectCollect += HandleDestroyableObjectCollect;
    }

    private void OnDisable()
    {
        DestroyableObjectTrigger.OnDestroyableObjectCollect -= HandleDestroyableObjectCollect;
    }

    private void HandleDestroyableObjectCollect()
    {
        AddScore(100); // add 100 points per 1 object
    }

}
