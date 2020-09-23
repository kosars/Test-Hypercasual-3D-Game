using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    public levelObject[] spawnObj;
    [SerializeField]
    public GameObject endOfLevel;
    [SerializeField]
    private Transform level;

    private float spawnHight = 2f;
    private float spawnOffset = BallMovement.moveSpeed;
    private float lastSpawnPosition;
    private int targetScore;
    /*private Transform m_Transform;*/


    private void Awake()
    {
        SpawnSingle(0, lastSpawnPosition + spawnOffset);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 25f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 50f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 75f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 100f);
        SpawnSingle(1, lastSpawnPosition + spawnOffset);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 100f);
        SpawnCircleRow(1, 3, lastSpawnPosition + spawnOffset, 0f, 30f);
        SpawnRow(0, 5, lastSpawnPosition + spawnOffset);

        SpawnSingle(0, lastSpawnPosition + spawnOffset);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -25f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -50f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -75f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -25f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, 0f);
        SpawnRow(0, 5, lastSpawnPosition + spawnOffset, 30f, 5f);
        SpawnCircleRow(1, 5, lastSpawnPosition + spawnOffset, 0f, 36f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -75f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -50f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -25f);
        SpawnSingle(0, lastSpawnPosition + spawnOffset, -25f);

        SpawnTrigger(endOfLevel, lastSpawnPosition + spawnOffset);

        Score.TargetScore = Mathf.RoundToInt(targetScore*1.25f);
    }

    private void SpawnObject(int index, float zPosition)
    {
        Vector3 position = new Vector3(0.0f, spawnHight, zPosition);
        Quaternion rotation = Quaternion.Euler(Vector3.forward);

        Transform t = Instantiate(spawnObj[index].obj, position, rotation).transform;
        t.SetParent(level);

        targetScore += spawnObj[index].pieces;
    }

    private void SpawnObject(int index, float zPosition, float rotateAngle)
    {
        Vector3 position = new Vector3(0.0f, spawnHight, zPosition);
        Quaternion rotation = Quaternion.Euler(Vector3.forward);

        Transform t = Instantiate(spawnObj[index].obj, position, rotation).transform;
        RotateObject(t, rotateAngle);
        t.SetParent(level);

        targetScore += spawnObj[index].pieces;
    }

    private void SpawnSingle(int index, float zPosition)
    {
        lastSpawnPosition = zPosition;
        SpawnObject(index, zPosition);
    }

    private void SpawnSingle(int index, float zPosition, float rotateAngle)
    {
        lastSpawnPosition = zPosition;
        SpawnObject(index, zPosition, rotateAngle);
    }

    private void SpawnRow(int index, int objectsNumber, float zStartPosition)
    {
        float zPosition = zStartPosition;
        for (int index1 = 0; index1 < objectsNumber; ++index1)
        {
            SpawnObject(index, zPosition);
            zPosition += spawnObj[index].objLenght;
        }
        lastSpawnPosition = zPosition;
    }

    private void SpawnRow(
      int index,
      int objectsNumber,
      float zStartPosition,
      float startRotateAngle,
      float rotateSpiralAngle)
    {
        float zPosition = zStartPosition;
        float rotateAngle = startRotateAngle;
        for (int index1 = 0; index1 < objectsNumber; ++index1)
        {
            SpawnObject(index, zPosition, rotateAngle);
            zPosition += spawnObj[index].objLenght;
            rotateAngle += rotateSpiralAngle;
        }
        lastSpawnPosition = zPosition + spawnOffset;
    }

    private void SpawnCircleRow(
      int index,
      int objectsNumber,
      float zStartPosition,
      float startRotateAngle,
      float rotateSpiralAngle)
    {
        float zPosition = zStartPosition;
        float rotateAngle = startRotateAngle;
        for (int index1 = 0; index1 < objectsNumber; ++index1)
        {
            SpawnObject(index, zPosition, rotateAngle);
            rotateAngle += rotateSpiralAngle;
        }
        lastSpawnPosition = zStartPosition;
    }

    private void SpawnTrigger(GameObject obj, float zPosition)
    {
        Vector3 position = new Vector3(0.0f, 0.0f, zPosition);
        Quaternion rotation = Quaternion.Euler(Vector3.forward);
        Instantiate<GameObject>(obj, position, rotation);
    }

    private void RotateObject(Transform transform, float rotateAngle) => transform.RotateAround(Vector3.zero, Vector3.forward, rotateAngle);

    [Serializable]
    public class levelObject
    {
        [SerializeField]
        public GameObject obj;
        [SerializeField]
        public float objLenght;
        [SerializeField]
        public int pieces;
    }
}
