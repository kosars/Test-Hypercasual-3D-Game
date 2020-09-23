using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    [SerializeField] private GameObject speedUP;

    private float m_Multiplier = 1f;
    private float m_SpeedMultiplier = 1f;
    private float speedAnimationTime = 2f;


    private void Start() => m_TextMeshPro = GetComponent<TextMeshProUGUI>();
    private void Update()
    {

        speedAnimationTime -= Time.deltaTime;

        if (speedAnimationTime <= 0)
            speedUP.SetActive(false);
    }
    private void ChangeMultiplier(float value) 
    {
        if (value == 1f)
            m_TextMeshPro.enabled = false;
        else
            m_TextMeshPro.enabled = true;
        m_Multiplier = value;
        SpeedMultiplier = value;
        m_TextMeshPro.text ="x" + value.ToString("0.0"); 
    }

    public float multiplier
    {
        get => m_Multiplier;
        set 
        {
            ChangeMultiplier(value);
        }
    }

    public float SpeedMultiplier
    {
        get => m_SpeedMultiplier;
        private set
        {
            float prev = m_SpeedMultiplier;
            m_SpeedMultiplier = (value - ((value) % 0.5f));
            

            if (m_SpeedMultiplier > prev)
            {
                speedAnimationTime = 2f;
                speedUP.SetActive(true);
                Debug.Log("SPEED UP! Speed x" + m_SpeedMultiplier);
            }

        }
    }
}
