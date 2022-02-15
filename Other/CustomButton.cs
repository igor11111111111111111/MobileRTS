using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : Button
{
    public event Action OnDown;
    private bool _down;

    public override void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _down = false;
    }

    private void FixedUpdate()
    {
        if (_down)
            OnDown.Invoke();
    }
}
