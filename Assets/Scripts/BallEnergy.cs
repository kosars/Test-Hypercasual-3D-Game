using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEnergy : MonoBehaviour
{
    private float currentEnergy = 1f;
    private float currentMaxEnergy = 1f;
    private float energyLostPerSec = 0.25f;
    private float standartScale = 1f;
    string voronoiName;
    string noiseName;
    private float standartVoronoi = 3.6f;
    private float standartNoise = 2f;



    private Transform m_Transform;
    private Renderer m_Renderer;

    void Start()
    {
        m_Transform = GameObject.Find("Fire").transform;
        //GetComponent<Renderer>().sharedMaterial.SetFloat("_YourParameter", someValue);
        m_Renderer = gameObject.GetComponent<Renderer>();
        //m_Shader.GetPropertyType
        voronoiName = m_Renderer.material.shader.GetPropertyName(8);
        noiseName = m_Renderer.material.shader.GetPropertyName(10);
        standartVoronoi = m_Renderer.sharedMaterial.GetFloat(voronoiName);
        standartNoise = m_Renderer.sharedMaterial.GetFloat(noiseName);

    }

    void FixedUpdate()
    {
        Energy -= energyLostPerSec * Time.deltaTime;
    }

    public void UpEnergy(float value)
    {
        if (Energy + value > currentMaxEnergy)
            Energy = currentMaxEnergy;
        else
            Energy += value;
    }

    public float Energy
    {
        get => currentEnergy;
        set
        {
            currentEnergy = value;
            SetSize(value);
            SetLook(value);
            if (value <= 0)
            {
                gameObject.GetComponent<BallCollision>().Die();
            }
        }
    }

    private void SetSize(float value)
    {
        m_Transform.localScale = Vector3.one * standartScale * value;
    }

    private void SetLook(float value)
    {
        float voronoi = standartVoronoi + (1f - value) * 2f;
        float noise = standartNoise + (1f - value) * 2f;
        m_Renderer.sharedMaterial.SetFloat(voronoiName, voronoi);
        m_Renderer.sharedMaterial.SetFloat(noiseName, noise);
    }
}
