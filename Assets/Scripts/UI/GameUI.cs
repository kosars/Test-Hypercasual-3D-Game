using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] public GameObject _startMenuUI;
    [SerializeField] public GameObject _restartMenuUI;
    [SerializeField] public GameObject _endMenuUI;
    [SerializeField] public GameObject _multiplierUI;
    [SerializeField] public GameObject _inGameUI;


    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        int res = Screen.height / 16;
        Screen.SetResolution(res * 9, Screen.height, true);
        Screen.fullScreen = true;
#endif
        PauseGame();

    }
    private void OnEnable()
    {
        PlayerEnergy.OnFullEnergyLost += Defeat;
        LevelCompleteTrigger.OnLevelComplete += Win;

    }

    private void OnDisable()
    {
        PlayerEnergy.OnFullEnergyLost -= Defeat;
        LevelCompleteTrigger.OnLevelComplete -= Win;

    }

    public void StartGame()
    {
        _multiplierUI.SetActive(true);
        _startMenuUI.SetActive(false);
        _endMenuUI.SetActive(false);
        _inGameUI.SetActive(true);

        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        _startMenuUI.SetActive(true);
        _inGameUI.SetActive(false);

        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        _startMenuUI.SetActive(false);
        _endMenuUI.SetActive(false);
        _restartMenuUI.SetActive(false);
        _inGameUI.SetActive(false);

        SceneManager.LoadScene("SampleScene");
    }

    public void Win()
    {
        _multiplierUI.SetActive(false);
        _endMenuUI.SetActive(true);
        _inGameUI.SetActive(false);

    }

    public void Defeat()
    {
        _restartMenuUI.SetActive(true);
        _inGameUI.SetActive(false);

    }
}
