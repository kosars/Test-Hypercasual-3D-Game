using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    private void FixedUpdate()
     {
        float rotateDirection = Input.GetAxis("Horizontal");
        _playerMovement.MoveSpiral(rotateDirection);
     }

    private void OnEnable()
    {
        PlayerEnergy.OnFullEnergyLost += HandleFullEnergyLost;
    }

    private void OnDisable()
    {
        PlayerEnergy.OnFullEnergyLost -= HandleFullEnergyLost;
    }
    private void HandleFullEnergyLost()
    {
        //DISABLE CHARACTERMOVEMENT WHEN DEAD
        _playerMovement.enabled = false;
        //DISABLE CHARACTERINPUT WHEN DEAD
        this.enabled = false;
    }
}
