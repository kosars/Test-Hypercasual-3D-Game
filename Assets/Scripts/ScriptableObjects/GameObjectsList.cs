using UnityEngine;

[CreateAssetMenu(menuName = "Game/GameObjectsList", fileName = "New Objects List")]
public class GameObjectsList : ScriptableObject
{
    [SerializeField] private GameObject[] _gameObjects;

    public GameObject[] GetObjects{ get => _gameObjects;}   
}
