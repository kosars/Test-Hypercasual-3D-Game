using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _starPrefab;
    [SerializeField] private GameObject _piecePrefab;

    private Vector3[] _starsCoords = new Vector3[3]
    {
        new Vector3(-2f, 7f, 12f),
        new Vector3(0f, 8f, 12f),
        new Vector3(2f, 7f, 12f)
    };
    private Vector3[] starPieceCoords;

    private void OnEnable() => LevelCompleteTrigger.OnLevelComplete += HandleLevelComplete;
    private void OnDisable() => LevelCompleteTrigger.OnLevelComplete -= HandleLevelComplete;

    private void HandleLevelComplete()
    {
        //TODO: MAKE DEPENDENCY INJECTION
        GetFigure(_starPrefab);
        Vector3 starSpawnpoint = transform.position;
        int starsCount = CountStars();
        //
        StartCoroutine(SpawnStars(starSpawnpoint, starsCount));
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
        for (int index = 0; index < starPieceCoords.Length; ++index)
        {
            Vector3 vector3 = starPieceCoords[index];
            Quaternion rotation = Quaternion.Euler(Vector3.forward);
            GameObject gameObject = Instantiate(_piecePrefab, starSpawnpoint, rotation);

            gameObject.GetComponent<StarPiece>().moveTo = vector3 + starCoords + Vector3.forward; // * cameraTransform.position.z
            gameObject.transform.parent = this.gameObject.transform;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void GetFigure(GameObject parent)
    {
        List<Vector3> vector3List = new List<Vector3>();
        if (parent == null)
            return;
        foreach (Transform transform in parent.transform)
        {
            if (null == transform)
                return;
            vector3List.Add(transform.gameObject.transform.position);
        }
        starPieceCoords = vector3List.ToArray();
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
