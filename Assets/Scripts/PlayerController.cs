using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private BallMovement m_BallMovement;

    private void Start()
    {
        if(null == m_BallMovement)
            m_BallMovement = GetComponentInChildren<BallMovement>();
    }


    private void Update() => m_BallMovement.RotateDirection = Input.GetAxis("Horizontal");
}