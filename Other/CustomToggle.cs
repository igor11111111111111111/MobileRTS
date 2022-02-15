using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    [SerializeField]
    private Sprite _zoom;
    [SerializeField]
    private Sprite _rotate;
    private Toggle _toggle;

    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        SetSprite(true);
        _toggle.onValueChanged.AddListener(SetSprite);
    }

    public bool IsOn()
    {
        return _toggle.isOn;
    }

    private void SetSprite(bool active)
    {
        if (active)
        {
            _toggle.image.sprite = _rotate;
        }

        else
        {
            _toggle.image.sprite = _zoom;
        }
    }
}
