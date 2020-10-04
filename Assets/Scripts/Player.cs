using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Transform _mainCamera;


    private void FixedUpdate()
     {
        float rotateDirection = Input.GetAxis("Horizontal");
        _playerMovement.MoveSpiral(rotateDirection);
     }

    private void OnEnable()
    {
        PlayerEnergy.OnFullEnergyLost += HandleFullEnergyLost;
        LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    }

    private void OnDisable()
    {
        PlayerEnergy.OnFullEnergyLost -= HandleFullEnergyLost;
        LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;
    }

    private void HandleFullEnergyLost()
    {
        _playerMovement.enabled = false;
        this.enabled = false;
    }

    private void HandleLevelComplete()
    {
        _mainCamera.SetParent(null, true);
        _mainCamera.position = new Vector3(0.0f, 5f, _mainCamera.position.z);
        Quaternion quaternion = Quaternion.Euler(10f, 0.0f, 0.0f);
        _mainCamera.rotation = quaternion;
    }
}
