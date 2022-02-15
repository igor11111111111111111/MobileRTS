using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelMover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private UnityEngine.GameObject _panel;
    [SerializeField]
    private float _speed = 4f;

    private RectTransform _rect;
    private Image _image;
    private bool _activated;
    private float _startPosY;
    private float _bexindScenePosY;

    private void Start()
    {
        _rect = _panel.GetComponent<RectTransform>();
        _image = GetComponent<Image>();

        _startPosY = _rect.anchoredPosition.y;
        _bexindScenePosY = _rect.anchoredPosition.y - _rect.sizeDelta.y;
        _rect.anchoredPosition = new Vector3(0, _bexindScenePosY, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _activated = true;
        ChangeAlpha(0f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _activated = false;
        ChangeAlpha(0.15f);
    }

    private void Update()
    {
        if (_activated && _rect.anchoredPosition.y <= _startPosY)
        {
            _rect.anchoredPosition = new Vector3(0, _rect.anchoredPosition.y + _speed, 0);
        }
        else if (!_activated && _rect.anchoredPosition.y > _bexindScenePosY)
        {
            _rect.anchoredPosition = new Vector3(0, _rect.anchoredPosition.y - _speed, 0);
        }
    }

    private void ChangeAlpha(float value)
    {
        var tempColor = _image.color;
        tempColor.a = value;
        _image.color = tempColor;
    }
}
