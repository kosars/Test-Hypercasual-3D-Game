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
}
