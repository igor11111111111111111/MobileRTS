
using UnityEngine;

public class PCCameraController : MonoBehaviour
{
    private Transform _camera;
    [SerializeField]
    [Range(0.5f, 2)]
    private float _speed;
    [SerializeField] private RectTransform _efficiencyPercentsPanel;
    private const float _coeffMove = 0.4f;
    private const float _coeffZoom = 0.2f;
    private const float _coeffRotation = 0.8f;

    void Start()
    {
        _camera = Camera.main.transform;

        _speed = 1;
    }

    void Update()
    {
        ButtonMove();
        ButtonRotate();
    }

    private void ButtonMove()
    {
        var _angleRad = _camera.localEulerAngles * Mathf.Deg2Rad;

        if (Input.GetKey(KeyCode.W))
        {
            NewPosition(Mathf.Sin(_angleRad.y), 0, Mathf.Cos(_angleRad.y));
        }

        if (Input.GetKey(KeyCode.A))
        {
            _camera.position -= _camera.right * _coeffMove * _speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            NewPosition(-Mathf.Sin(_angleRad.y), 0, -Mathf.Cos(_angleRad.y));
        }

        if (Input.GetKey(KeyCode.D))
        {
            _camera.position += _camera.right * _coeffMove * _speed;
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (Camera.main.orthographicSize < 30)
                Camera.main.orthographicSize += _coeffZoom * _speed;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (Camera.main.orthographicSize > 2)
                Camera.main.orthographicSize -= _coeffZoom * _speed;
        }
    }

    private void NewPosition(float x, float y, float z)
    {
        Vector3 offset = new Vector3(x, y, z);
        _camera.position = Vector3.Lerp(_camera.position, _camera.position + offset, _coeffMove * _speed);
    }

    private void ButtonRotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Rotate(1);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Rotate(-1);
        }
    }

    private void Rotate(float signDirection)
    {
        Vector3 eulers = new Vector3(0, Mathf.Sign(signDirection) * _coeffRotation * _speed, 0);

        _camera.Rotate(eulers, Space.World);
        _efficiencyPercentsPanel.Rotate(eulers, Space.World);
    }
}