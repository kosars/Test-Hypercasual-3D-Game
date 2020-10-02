using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpeedUpUI : MonoBehaviour
{
    [SerializeField] private GameObject _speedUP;
    //[SerializeField] private GameObject _speedParticles;

    private void Awake() => Deactivate();
    private void OnEnable()
    {
        PlayerMultiplier.OnSpeedUp += HandleSpeedUp;
        LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    }

    private void OnDisable()
    {
        PlayerMultiplier.OnSpeedUp += HandleSpeedUp;
        LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;
    }
    private void Activate()
    {
        _speedUP.SetActive(true);
        //_speedParticles.SetActive(true);
        DeactivateAfterTime(2f);
    }

    private void Deactivate()
    {
        _speedUP.SetActive(false);
        //_speedParticles.SetActive(false);
    }

    private void HandleSpeedUp() => Activate();
    //TODO: SPEED UP ANIMATION
    private void HandleLevelComplete() => Deactivate();

    IEnumerator DeactivateAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        Deactivate();
    }
}
