using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SquadController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public UnityAction OnDisactive;
    public bool Active => _active;
    private bool _active;
    private bool _oldActive;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Sprite _activeSprite;
    [SerializeField]
    private Sprite _unactiveSprite;
    public TouchController TouchController;
    public PositionOnGesture PositionOnGesture;

    private void Start()
    {
        _active = _oldActive = false;
    }

    private void Update()
    {
        if(_oldActive != _active && !_active)
        {
            OnDisactive?.Invoke();
        }

        _oldActive = _active;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _active = true;
        _image.sprite = _activeSprite;
        TouchController.enabled = false;
        PositionOnGesture.enabled = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _active = false;
        _image.sprite = _unactiveSprite;
        TouchController.enabled = true;
        //PositionOnGesture.enabled = false;
    }
}
