using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public GameObject star;
    public GameObject piece;
    private GameMenu m_GameMenu;
    private int starsCount;
    private bool isEnd;
    private Vector3 starSpawnpoint;
    private Vector3[] starsCoords = new Vector3[3]
    {
    new Vector3(-2f, 3f, 10f),
    new Vector3(0.0f, 4f, 10f),
    new Vector3(2f, 3f, 10f)
    };
    private Vector3[] starPieceCoords;

    private void Start()
    {
        getFigure(star);
        m_GameMenu = GameObject.Find("Canvas").GetComponent<GameMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.name == "Ball"))
            return;
        EndLevel();
    }

    private void EndLevel()
    {
        isEnd = true;
        m_GameMenu.EndGame();
        GameObject gameObject = GameObject.Find("Ball");
        starSpawnpoint = GameObject.Find("BlowingPoint").transform.position;
        foreach (Transform transform in gameObject.transform)
            transform.SetParent((Transform)null, true);
        Transform transform1 = GameObject.Find("Main Camera").transform;
        transform1.position = new Vector3(0.0f, 10f, transform1.position.z);
        Quaternion quaternion = Quaternion.Euler(20f, 0.0f, 0.0f);
        transform1.rotation = quaternion;
        starsCount = GameObject.Find("Score").GetComponent<Score>().CountStars();
        for (int index = 0; index < starsCoords.Length && index < starsCount; ++index)
            StartCoroutine(spawnStar(starsCoords[index]));
    }

    private void Update()
    {
        int num = isEnd ? 1 : 0;
    }

    private void getFigure(GameObject parent)
    {
        List<Vector3> vector3List = new List<Vector3>();
        if ((Object)parent == (Object)null)
            return;
        foreach (Transform transform in parent.transform)
        {
            if ((Object)null == (Object)transform)
                return;
            vector3List.Add(transform.gameObject.transform.position);
        }
        starPieceCoords = vector3List.ToArray();
    }

    private IEnumerator spawnStar(Vector3 starCoords)
    {
        EndOfLevel endOfLevel = this;
        Vector3[] vector3Array = endOfLevel.starPieceCoords;
        for (int index = 0; index < vector3Array.Length; ++index)
        {
            Vector3 vector3 = vector3Array[index];
            Quaternion rotation = Quaternion.Euler(Vector3.forward);
            GameObject gameObject = Object.Instantiate<GameObject>(endOfLevel.piece, endOfLevel.starSpawnpoint, rotation);
            gameObject.transform.parent = endOfLevel.gameObject.transform;
            gameObject.GetComponent<StarPiece>().moveTo = vector3 + starCoords + endOfLevel.starSpawnpoint;
            yield return (object)new WaitForSeconds(0.05f);
        }
        vector3Array = (Vector3[])null;
    }
}
