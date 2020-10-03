using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/LevelData", fileName = "New Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int _number;
    [SerializeField] private int _targetScore;
    [SerializeField] private GameObjectsList _gameObjects;
    [SerializeField] private List<ObjectsRow> _levelObjects;


    public int Number { get => _number; }
    public string Name { get => "Level " + _number.ToString(); }
    public int TargetScore { get => _targetScore; }
    public List<ObjectsRow> LevelObjects { get => _levelObjects; }
    public GameObject[] GameObjects { get => _gameObjects.GetObjects; }

}

[System.Serializable]
public class ObjectsRow
{
    [SerializeField] private int _gameObjectsIndex;
    [SerializeField] private int _levelObjectsAmount = 1;
    [SerializeField] private float _rotationStartAngle = 0f; //start Angle rotation in row
    [SerializeField] private float _rotationBeetweenAngle = 0f; //rotation angle beetwen objects
    [SerializeField] private float _startOffset = 10f;
    [SerializeField] private float _beetweenOffset = 1f; //offset beetwen 

    public int Index { get => _gameObjectsIndex; }
    public int Amount { get => _levelObjectsAmount; }
    public float StartAngle { get => _rotationStartAngle; }
    public float BeetweenAngle { get => _rotationBeetweenAngle; }
    public float StartOffset { get => _startOffset; }
    public float BeetweenOffset { get => _beetweenOffset; }



}