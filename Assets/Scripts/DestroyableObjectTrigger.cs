using System;
using TMPro;
using UnityEngine;

public class DestroyableObjectTrigger : MonoBehaviour
{
    public static event Action OnDestroyableObjectCollect;

    [SerializeField] private DestroyableObjectMovement _destroyableObjectMovement;
    [SerializeField] private GameObject _scoreText;


    private void Awake()
    {
        _destroyableObjectMovement.enabled = false;
        _scoreText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name == "Ball"))
            return;
        _destroyableObjectMovement.enabled = true;
        OnDestroyableObjectCollect?.Invoke(); 
        _scoreText.SetActive(true);
        _scoreText.GetComponent<TextMeshPro>().text = PlayerScore.DeltaScore.ToString();
        this.enabled = false;
    }
}
