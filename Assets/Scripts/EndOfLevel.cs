using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public GameObject star;
    public GameObject piece;
    public GameMenu m_GameMenu;

    private int starsCount;
    private Transform cameraTransform;
   // private bool isEnd;
    private Vector3 starSpawnpoint;
    private Vector3[] starsCoords = new Vector3[3]
    {
        new Vector3(-2f, 7f, 12f),
        new Vector3(0f, 8f, 12f),
        new Vector3(2f, 7f, 12f)
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
        //isEnd = true;
        m_GameMenu.EndGame();

        GameObject ball = GameObject.Find("Ball");
        foreach (Transform transform in ball.transform)
            transform.SetParent(null, true);
        cameraTransform = GameObject.Find("Main Camera").transform;
        cameraTransform.position = new Vector3(0.0f, 10f, cameraTransform.position.z);
        Quaternion quaternion = Quaternion.Euler(20f, 0.0f, 0.0f);
        cameraTransform.rotation = quaternion;

        starSpawnpoint = GameObject.Find("BlowingPoint").transform.position;
        starsCount = GameObject.Find("Score").GetComponent<Score>().CountStars();
         
        StartCoroutine(spawnStars());
    }

    /*private void Update()
    {
        int num = isEnd ? 1 : 0;
    }*/

    private void getFigure(GameObject parent)
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
    private IEnumerator spawnStars()
    {
        for (int index = 0; index < starsCoords.Length && index < starsCount; ++index)
        {
            StartCoroutine(spawnStarPieces(starsCoords[index]));
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator spawnStarPieces(Vector3 starCoords)
    { 
        for (int index = 0; index < starPieceCoords.Length; ++index)
        {
            Vector3 vector3 = starPieceCoords[index];
            Quaternion rotation = Quaternion.Euler(Vector3.forward);
            GameObject gameObject = Instantiate(piece,starSpawnpoint, rotation);

            gameObject.GetComponent<StarPiece>().moveTo = vector3 + starCoords + Vector3.forward * cameraTransform.position.z;
            gameObject.transform.parent = this.gameObject.transform;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
