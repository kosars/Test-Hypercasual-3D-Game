using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject endMenuUI;
    public Score m_Score;

    private void Awake() => PauseGame();

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        endMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void EndGame() => endMenuUI.SetActive(true);

    public void RestartGame()
    {
        startMenuUI.SetActive(false);
        endMenuUI.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
