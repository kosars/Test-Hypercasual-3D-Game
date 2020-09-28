using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    //TODO: ChangeScoreLogic
    public static event Action OnScoreChange;
    [SerializeField] private PlayerMultiplier _multiplier;

    //TODO: PlayerSoreUI
    private static int _currentScore;
    private static int _targetScore;

    public static int CurrentScore
    {
        get => _currentScore;
        private set
        {
            _currentScore = value;
            OnScoreChange.Invoke();
        }
    }
    public static int TargetScore
    {
        get => _targetScore;
        set => _targetScore = value;
    }

    //TODO: Move CountStars To StarsSpawner Or LevelComplete script
    public int CountStars()
    {
        float num = (_currentScore / (_targetScore / 100));
        Debug.Log((_targetScore.ToString() + ", " + num + "%"));
        if (num < 10.0)
            return 0;
        if (num < 50.0)
            return 1;
        return num < 80.0 ? 2 : 3;
    }

    public void AddScore(int value)
    {
        CurrentScore += (int)(value * _multiplier.Multiplier);
    }

}
