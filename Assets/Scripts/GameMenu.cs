using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] public GameObject startMenuUI;
    [SerializeField] public GameObject restartMenuUI;
    [SerializeField] public GameObject endMenuUI;
    [SerializeField] public Score m_Score;

    private void Awake() => PauseGame();

    public  void StartGame()
    {
        startMenuUI.SetActive(false);
        endMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public  void PauseGame()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public  void EndGame() => endMenuUI.SetActive(true);

    public  void RestartGame()
    {
        startMenuUI.SetActive(false);
        endMenuUI.SetActive(false);
        restartMenuUI.SetActive(false);

        SceneManager.LoadScene("SampleScene");
    }

    public  void Defeat()
    {
        restartMenuUI.SetActive(true);
    }
}
