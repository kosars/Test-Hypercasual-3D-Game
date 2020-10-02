using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable()
    {
        PlayerScore.OnScoreChange += HandleScoreChange;
    }
    private void OnDisable()
    {
        PlayerScore.OnScoreChange -= HandleScoreChange;

    }

    private void HandleScoreChange(int score)
    {
        _textMeshPro.text = score.ToString();
    }
}
