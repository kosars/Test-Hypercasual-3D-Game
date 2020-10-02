using TMPro;
using UnityEngine;

public class MultiplierUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;

    private void OnEnable() =>  PlayerMultiplier.OnMultiplierChange += HandleMultiplierChange;
    private void OnDisable() => PlayerMultiplier.OnMultiplierChange -= HandleMultiplierChange;

    private void HandleMultiplierChange(float multiplier)
    {
        _textMeshPro.text = "x" + multiplier.ToString("0.0");

        //hide not increased multiplier
        if (multiplier == 1f)
            _textMeshPro.enabled = false;
        else
            _textMeshPro.enabled = true;

    }
}
