using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private Transform beam;
    [SerializeField] private Transform fire;

    [SerializeField] private Multiplier m_Multiplier;
    [SerializeField] private BallEnergy m_BallEnergy;

    [SerializeField] public GameMenu m_GameMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CometRotation>() != null
            || collision.gameObject.GetComponent<CometFacing>() != null)
        {
            m_BallEnergy.UpEnergy(-0.5f);
            m_Multiplier.multiplier = 1f;
            //Die();

        }
    }

    public void Die()
    {
        this.gameObject.GetComponent<BallMovement>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        fire.gameObject.SetActive(false);

        beam.gameObject.SetActive(true);
        m_GameMenu.Defeat();
    }
}
