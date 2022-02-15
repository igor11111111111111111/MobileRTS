using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class PositionOnGesture : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ 
    public static event UnityAction<Vector3, Vector3> OnMoveUp;
    public static event UnityAction<Vector3> OnMoveDown; 
    public static event UnityAction<Vector3> OnMove;
    public static event UnityAction<Vector3> OnSelectUp;
    public static event UnityAction<Vector3> OnSelectDown;
    public static event UnityAction<Vector3> OnSelect;

    private PointerEventData _eventData;
    [SerializeField]
    private SquadController _controller;
    private bool _clampedMove = false;
    private bool _clampedSelect = false;
    private Vector3 _startPosition;
    private Vector3 _endPosition;

    private void OnEnable()
    {
        _controller.OnDisactive += () =>
        {
            Disactive();
            enabled = false;
        };
    }

    private void OnDisable()
    {
        _controller.OnDisactive -= () =>
        {
            Disactive();
            enabled = false;
        };
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        if (_controller.Active)
        {
            if (SwitchMouse.CurrentSwitch == Enums.Switch.Moving)
            {
                _clampedMove = true;
                _eventData = eventData;

                _startPosition = eventData.pointerCurrentRaycast.worldPosition;
                OnMoveDown?.Invoke(_startPosition);
            }

            else if (SwitchMouse.CurrentSwitch == Enums.Switch.Selection)
            {
                _clampedSelect = true;
                OnSelectDown?.Invoke(Input.GetTouch(1).position);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Disactive();
    }

    private void Disactive()
    {
        if (SwitchMouse.CurrentSwitch == Enums.Switch.Moving && _clampedMove)
        {
            _clampedMove = false;
            OnMoveUp?.Invoke(_startPosition, _endPosition);
        }

        else if (SwitchMouse.CurrentSwitch == Enums.Switch.Selection && _clampedSelect)
        {
            _clampedSelect = false;
            OnSelectUp?.Invoke(Input.GetTouch(1).position);
        }
    }

    private void Update()
    {
        if (_eventData != null && _clampedMove)
        {
            _endPosition = _eventData.pointerCurrentRaycast.worldPosition;
            OnMove?.Invoke(_endPosition);
        }

        if (_clampedSelect)
        {
            OnSelect.Invoke(Input.GetTouch(1).position);
        }
    }
}
