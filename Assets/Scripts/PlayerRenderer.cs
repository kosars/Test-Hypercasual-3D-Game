using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private float _standartFireScale = 1f;
    private string _voronoiName;
    private string _noiseName;
    private float _standartVoronoi = 1.6f; //TODO Make all data get from the ScriptableObject
    private float _standartNoise = 2f;



    [SerializeField] private Transform _fireTransform;
    [SerializeField] private Renderer _playerRenderer;
    [SerializeField] private Transform _beamTransform;


    private void Awake()
    {
        _voronoiName = _playerRenderer.material.shader.GetPropertyName(8);
        _noiseName = _playerRenderer.material.shader.GetPropertyName(10);
        _standartVoronoi = _playerRenderer.sharedMaterial.GetFloat(_voronoiName);
        _standartNoise = _playerRenderer.sharedMaterial.GetFloat(_noiseName);
    }

    private void OnEnable()
    {
        PlayerEnergy.OnEnergyChange += HandleEnergyChange;
        PlayerEnergy.OnFullEnergyLost += HandleFullEnergyLost;
    }

    private void OnDisable()
    {
        PlayerEnergy.OnEnergyChange -= HandleEnergyChange;
        PlayerEnergy.OnFullEnergyLost -= HandleFullEnergyLost;
    }

    private void HandleEnergyChange(float energyValue)
    {
        SetSize(energyValue);
        SetLook(energyValue);
    }

    private void HandleFullEnergyLost()
    {
        _playerRenderer.enabled = false;
        _fireTransform.gameObject.SetActive(false);
        _beamTransform.gameObject.SetActive(true);
    }

    private void SetSize(float value)
    {
        _fireTransform.localScale = Vector3.one * _standartFireScale * value;
    }

    private void SetLook(float value)
    {
        float voronoi = _standartVoronoi + (1f - value) * 4f;
        float noise = _standartNoise + (1f - value) * 2f;
        _playerRenderer.sharedMaterial.SetFloat(_voronoiName, voronoi);
        _playerRenderer.sharedMaterial.SetFloat(_noiseName, noise);
        //TODO OPTIMIZE TO CHANGE ONLY PROPERTY
    }
}
