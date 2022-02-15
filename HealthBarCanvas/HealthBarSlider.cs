using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    [SerializeField]
    private RectTransform _rectTransform;
    [SerializeField]
    private Image _fillImage;
    [SerializeField]
    private Slider _slider;

    public void ApplySettings(Unit unit, Camera camera)
    {
        var position = camera.WorldToViewportPoint(unit.transform.position);

        _rectTransform.anchorMin = position;
        _rectTransform.anchorMax = position;
         
        _rectTransform.gameObject.SetActive(true);

        _slider.value = unit.NormalizedHealth;
        _fillImage.color = ColorUnitHealth.GetColor(unit.NormalizedHealth);
    }
}
