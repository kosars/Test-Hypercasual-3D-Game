using TMPro;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_TextMeshPro;
    private float m_Multiplier = 1f;

    private void Start() => m_TextMeshPro = GetComponent<TextMeshProUGUI>();

    private void ChangeMultiplier(float value) 
    {
        if (value == 1f)
            m_TextMeshPro.enabled = false;
        else
            m_TextMeshPro.enabled = true;
        m_Multiplier = value;
        m_TextMeshPro.text ="x" + value.ToString(); 
    }

    public  float multiplier
    {
        get => m_Multiplier;
        set 
        {
            ChangeMultiplier(value);
        }
    }
}
