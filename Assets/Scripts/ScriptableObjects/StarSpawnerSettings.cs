using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/StarSpawnerSettings", fileName = "New StarSpawner Settings")]
public class StarSpawnerSettings : ScriptableObject
{
    [SerializeField] private GameObject _starPrefab;
    [SerializeField] private float _pieceMoveSpeed = 5f;
    [SerializeField] private Vector3 _spawnPoint;

    [SerializeField] private Vector3[] _starsCoords = new Vector3[3] //make sure it's relative to camera
    {
        new Vector3(-2f, 7f, 12f),
        new Vector3(0f, 8f, 12f),
        new Vector3(2f, 7f, 12f)
    };

    public float PieceMoveSpeed
    {
        get => _pieceMoveSpeed;
        private set => _pieceMoveSpeed = value;
    }

    public Vector3[] StarsCoords
    {
        get => _starsCoords;
        private set => _starsCoords = value;
    }
    public Vector3 SpawnPoint
    {
        get => _spawnPoint;
        private set => _spawnPoint = value;
    }

    public Vector3[] StarPieceCoords
    {
        get => GetFigure(_starPrefab);
    }

    private Vector3[] GetFigure(GameObject parent)
    {
        List<Vector3> vector3List = new List<Vector3>();
        if (parent == null)
            return new Vector3[0];
        foreach (Transform transform in parent.transform)
        {
            if (null == transform)
                return new Vector3[0];
            vector3List.Add(transform.gameObject.transform.position);
        }
        return vector3List.ToArray();
    }
}
