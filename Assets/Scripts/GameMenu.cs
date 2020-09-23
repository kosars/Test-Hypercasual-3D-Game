using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] public GameObject startMenuUI;
    [SerializeField] public GameObject restartMenuUI;
    [SerializeField] public GameObject endMenuUI;
    [SerializeField] public GameObject multiplierUI;
    [SerializeField] public Score m_Score;


    private void Awake() 
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
                int res = Screen.height / 16;
                Screen.SetResolution(res*9, Screen.height, true);
                Screen.fullScreen = true;
        #endif
        PauseGame();

    }

    public void StartGame()
    {
        multiplierUI.SetActive(true);
        startMenuUI.SetActive(false);
        endMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        startMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void EndGame() 
    { 
        multiplierUI.SetActive(false);
        endMenuUI.SetActive(true); 
    }

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
