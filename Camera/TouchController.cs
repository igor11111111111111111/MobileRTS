
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IDragHandler
{
    [SerializeField] private SensitivityPanel _sensitivityPanel;
    [SerializeField] private RectTransform _efficiencyPercentsPanel;
    private Camera _camera;
    private float _sensCoef = 1;
    private float _swipeCoef = 0.25f;
    private float _zoomCoef = 0.10f;
    private float _rotateCoef = 16f;
    private const int _thresholdValue = 17;
    private float _cameraSize;

    private void OnEnable()
    {
        _sensitivityPanel.OnValueChanged += (value) => _sensCoef = value;
    }

    private void OnDisable()
    {
        _sensitivityPanel.OnValueChanged -= (value) => _sensCoef = value;
    }

    private void Start()
    {
        _camera = Camera.main;
        _cameraSize = _camera.orthographicSize / 15.73f;
    }

    private void Swipe()
    {
        Vector2 delta = -Input.GetTouch(0).deltaPosition * _swipeCoef * _sensCoef * _cameraSize;

        var angleRad = Camera.main.transform.localEulerAngles * Mathf.Deg2Rad;

        _camera.transform.position += new Vector3(
            delta.y * Mathf.Sin(angleRad.y) + delta.x * Mathf.Cos(angleRad.y),
            0,
            delta.y * Mathf.Cos(angleRad.y) + delta.x * -Mathf.Sin(angleRad.y));
    }

    private void TwoFingers()
    {
        Vector2 delta = Input.GetTouch(1).deltaPosition;

        if (delta.y > _thresholdValue || delta.y < -_thresholdValue)
        {
            Rotate(delta.y);
        }

        if (delta.x > _thresholdValue || delta.x < -_thresholdValue)
        {
            Zoom(delta.x);
        }
    }

    private void Rotate(float value)
    {
        Vector3 eulers = new Vector3(0, Mathf.Sign(value), 0) * _rotateCoef * _sensCoef * _cameraSize;
        _camera.transform.Rotate(eulers, Space.World);
        _efficiencyPercentsPanel.Rotate(eulers, Space.World);
    }

    private void Zoom(float value)
    {
        if ((value < 0 && _camera.orthographicSize < 30) ||
            (value > 0 && _camera.orthographicSize > 2))
        {
            _camera.orthographicSize -= value * _zoomCoef * _sensCoef;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.touchCount == 1) Swipe();

        else if (Input.touchCount == 2) TwoFingers();
    }
}
