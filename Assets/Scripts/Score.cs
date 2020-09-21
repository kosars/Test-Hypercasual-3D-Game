using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int currScore;
    private int targScore;
    private TextMeshProUGUI m_TextMeshPro;

    private void Start() => m_TextMeshPro = GetComponent<TextMeshProUGUI>();

    private void ChangeScore() => m_TextMeshPro.text = currScore.ToString();

    public int CountStars()
    {
        float num = (float)(currScore / (targScore / 100));
        Debug.Log((object)(targScore.ToString() + ", " + (object)num + "%"));
        if ((double)num < 10.0)
            return 0;
        if ((double)num < 50.0)
            return 1;
        return (double)num < 80.0 ? 2 : 3;
    }

    public int CurrentScore
    {
        get => currScore;
        set
        {
            currScore = value;
            ChangeScore();
        }
    }

    public int TargetScore
    {
        get => targScore;
        set => targScore = value;
    }
}
