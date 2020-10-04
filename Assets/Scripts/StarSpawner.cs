using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _piecePrefab;
    [SerializeField] private StarSpawnerSettings _starSpawnerSettings;

    private Vector3[] _starsCoords;
    private Vector3[] _starPieceCoords;
    private Vector3 _spawnPoint;
    private float _pieceSpeed;

    private void OnEnable() => LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    private void OnDisable() => LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;
    private void Awake()
    {
        _starsCoords = _starSpawnerSettings.StarsCoords; //TODO: IT WORKS BUT FOR SOME REASONS  TROWS NULLREFERENCE
        _starPieceCoords = _starSpawnerSettings.StarPieceCoords;
        _pieceSpeed = _starSpawnerSettings.PieceMoveSpeed; 
        _spawnPoint = _starSpawnerSettings.SpawnPoint;
    }

    private void HandleLevelComplete()
    {
        int starsCount = CountStars();
        StartCoroutine(SpawnStars(transform.position, starsCount));
    }

    private IEnumerator SpawnStars(Vector3 starSpawnpoint, int starsCount)
    {
        for (int index = 0; index < _starsCoords.Length && index < starsCount; ++index)
        {
            StartCoroutine(SpawnStarPieces(starSpawnpoint, _starsCoords[index]));
            yield return new WaitForSeconds(1f);
        }
    } 

    private IEnumerator SpawnStarPieces(Vector3 starSpawnpoint, Vector3 starCoords)
    {
        for (int index = 0; index < _starPieceCoords.Length; ++index)
        {
            Vector3 vector3 = _starPieceCoords[index];
            Quaternion rotation = Quaternion.Euler(Vector3.forward);
            GameObject gameObject = Instantiate(_piecePrefab, starSpawnpoint, rotation);
            StarPieceMovement starPieceMovement = gameObject.GetComponent<StarPieceMovement>();
            starPieceMovement.MoveSpeed = _pieceSpeed;
            starPieceMovement.MoveTo = transform.position + vector3 + starCoords; // * cameraTransform.position.z
            gameObject.transform.parent = this.gameObject.transform;
            yield return new WaitForSeconds(0.01f);
        }
    }
    private int CountStars()
    {
        float num = (PlayerScore.CurrentScore / (PlayerScore.TargetScore / 100));
        if (num < 10.0)
            return 0;
        if (num < 50.0)
            return 1;
        return num < 80.0 ? 2 : 3;
    }
}
