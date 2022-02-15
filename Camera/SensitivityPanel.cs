using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SensitivityPanel : MonoBehaviour
{
    public UnityAction<float> OnValueChanged;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    
    private void Start()
    {
        _slider.onValueChanged.AddListener((value) =>
        {
            OnValueChanged?.Invoke(value);
            _text.text = Math.Round(value, 2).ToString();
        });

        _slider.value = 1;
    }
}
