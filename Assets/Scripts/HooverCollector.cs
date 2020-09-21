using UnityEngine;

public class HooverCollector : MonoBehaviour
{
    private int itemsDestroyed;
    [SerializeField]private Score m_Score;

    private void Start()
    {
        if(null == m_Score)
            m_Score = GameObject.Find("Score").GetComponent<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.gameObject.tag != "NotDestroy"))
            return;
        Destroy(other.gameObject);
        ++itemsDestroyed;
        m_Score.CurrentScore = itemsDestroyed;
    }
}