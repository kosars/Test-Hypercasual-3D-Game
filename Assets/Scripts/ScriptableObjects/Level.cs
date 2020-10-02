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

}

[System.Serializable]
public class ObjectsRow
{
    public int _gameObjectsIndex;
    public int _levelObjectsAmount = 1;
    public float _rotationStartAngle = 0f; //start Angle rotation in row
    public float _rotationBeetweenAngle = 0f; //rotation angle beetwen objects
    public float _startOffset = 10f;
    public float _beetweenOffset = 1f; //offset beetwen 
}