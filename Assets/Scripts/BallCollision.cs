using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private Transform beam;
    [SerializeField] private Transform fire;

    [SerializeField] public GameMenu m_GameMenu;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CometRotation>() != null
            || collision.gameObject.GetComponent<CometFacing>() != null)
        {
            this.gameObject.GetComponent<BallMovement>().enabled = false;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;

            fire.gameObject.SetActive(false);

            beam.gameObject.SetActive(true);
            m_GameMenu.Defeat();

        }
    }
}
