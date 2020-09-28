using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Multiplier m_Multiplier;
    [SerializeField] private TextMeshProUGUI m_TextMeshPro; //TODO ScoreUI Script
    private int currScore;
    private static int targScore;
    

    private void Start() => m_TextMeshPro = GetComponent<TextMeshProUGUI>();

    private void ChangeScore() => m_TextMeshPro.text = currScore.ToString();

    public int CountStars()
    {
        float num = (currScore / (targScore / 100));
        Debug.Log((targScore.ToString() + ", " + num + "%"));
        if (num < 10.0)
            return 0;
        if (num < 50.0)
            return 1;
        return num < 80.0 ? 2 : 3;
    }

    public int CurrentScore
    {
        get => currScore;
        private set
        {
            currScore = value;
            ChangeScore();
        }
    } 
    public void AddScore(int value)
    {
        CurrentScore += (int)(value * m_Multiplier.multiplier);
    }

    public static int TargetScore
    {
        get => targScore;
        set => targScore = value;
    }
}
