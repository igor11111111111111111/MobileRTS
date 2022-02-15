using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class HealthBarCanvas : MonoBehaviour
{
    public bool AltPressed;
    public GameObject Slider;
    private List<Unit> _units = new List<Unit>();
    private List<HealthBarSlider> _sliders = new List<HealthBarSlider>();
    private Camera _camera;
    private Resolution _screenResolution;

    private void Start()
    {
        _camera = Camera.main;
        _screenResolution = Screen.currentResolution;
        AltPressed = false;

        InvokeRepeating("CustomUpdate", 0f, 0.05f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            AltPressed = !AltPressed;

            if(!AltPressed)
            {
                DisableSliders();
            }
        }
    }

    private void CustomUpdate()
    {
        if(AltPressed)
        {
            GetUnits();
            PoolSliders();
            SetSliderParameters();
        }
    }

    private void GetUnits()
    {
        _units.Clear();
        var endPos = new Vector3(_screenResolution.height, _screenResolution.width, 0);
        var colliders = PhysicsExtension.OverlapScreenBox(Vector3.zero, endPos, _camera);
        foreach (var collider in colliders)
        {
            Unit unit = collider.GetComponent<Unit>();
            if (unit != null && unit.Exists)
            {
                _units.Add(unit);
            }
        }
    }

    private void PoolSliders()
    {
        int missingRects = _units.Count - _sliders.Count;
        for (int i = 0; i < missingRects; i++)
        {
            var sider = Instantiate(Slider, transform).GetComponent<HealthBarSlider>();
            _sliders.Add(sider);
        }
        DisableSliders();
    }

    private void SetSliderParameters()
    {
        for (int i = 0; i < _units.Count; i++)
        {
            _sliders[i].ApplySettings(_units[i], _camera);
        }
    }

    public void DisableSliders()
    {
        foreach (HealthBarSlider slider in _sliders)
        {
            slider.gameObject.SetActive(false);
        }
    }
}
