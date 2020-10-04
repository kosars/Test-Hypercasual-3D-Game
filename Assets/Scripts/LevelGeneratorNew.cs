using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorNew : MonoBehaviour
{
    [SerializeField] private LevelData _currentLevel;
    [SerializeField] private GameObject _levelCompleteTrigger;
    [SerializeField] private GameObject _starSpawner;
    [SerializeField] private Transform _levelTransform;

    private float _spawnHight = 2f;//TODO: MAKE FROM GAME SETTINGS ScriptableObject

    private float _lastSpawnPosition;


    private void Awake()
    {
        GameObject[] gameObjects = _currentLevel.GameObjects;
        List<ObjectsRow> levelObjects = _currentLevel.LevelObjects;
        GenerateLevel(levelObjects, gameObjects);
        PlayerScore.TargetScore = _currentLevel.TargetScore;

    }

    private void GenerateLevel(List<ObjectsRow> levelObjects, GameObject[] gameObjects)
    {
        if (null == levelObjects 
            || null == gameObjects)
            return;
        foreach(ObjectsRow objectsRow in levelObjects)
        {
            SpawnRow(objectsRow, gameObjects);
        }

        SpawnTrigger(_levelCompleteTrigger, _lastSpawnPosition + 5f);
        SpawnTrigger(_starSpawner, _lastSpawnPosition + 5f);

    }

    private void SpawnObject(GameObject objectPrefab, float position, float rotation)
    {
        Vector3 pos = new Vector3(0.0f, _spawnHight, position);
        Quaternion rot = Quaternion.Euler(Vector3.forward);
        Transform t = Instantiate(objectPrefab, pos, rot).transform;
        RotateObject(t, rotation);
        t.SetParent(_levelTransform);
    }

    private void SpawnRow(ObjectsRow objectsRow, GameObject[] gameObjects)
    {
        float position = _lastSpawnPosition + objectsRow.StartOffset;
        float rotation = objectsRow.StartAngle;

        for (int i=0; i<objectsRow.Amount; i++)
        { 
            SpawnObject(
                gameObjects[objectsRow.Index],
                position,
                rotation);
            position += objectsRow.BeetweenOffset;
            rotation += objectsRow.BeetweenAngle;
        }

        _lastSpawnPosition = position - objectsRow.BeetweenOffset;
    }
    
    private void SpawnTrigger(GameObject obj, float zPosition)
    {
        Vector3 position = new Vector3(0.0f, 0.0f, zPosition);
        Quaternion rotation = Quaternion.Euler(Vector3.forward);
        Instantiate(obj, position, rotation);
    }

    private void RotateObject(Transform transform, float rotateAngle) => transform.RotateAround(Vector3.zero, Vector3.forward, rotateAngle);
}
