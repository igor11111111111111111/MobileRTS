using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCameraPanel : MonoBehaviour
{
    public CustomButton ZoomIn;
    public CustomButton ZoomOut;
    public CustomButton RotateLeft;
    public CustomButton RotateRight;

    public CustomButton MoveUp;
    public CustomButton MoveLeft;
    public CustomButton MoveDown;
    public CustomButton MoveRight;

    private Vector3 _angleRad;

    private Transform _camera;
    [SerializeField]
    [Range(0.5f, 2)]
    private float _speed;
    private const float _coeffMove = 0.4f;
    private const float _coeffZoom = 0.2f;
    private const float _coeffRotation = 0.8f;

    void Start()
    {
        _camera = Camera.main.transform;
        _speed = 2;
    }

    private void OnEnable()
    {
        ZoomIn.OnDown += ZoomInSub;
        ZoomOut.OnDown += ZoomOutSub;
        RotateLeft.OnDown += () => Rotate(-1);
        RotateRight.OnDown += () => Rotate(1);
        MoveUp.OnDown += MoweUpSub;
        MoveLeft.OnDown += MoweLeftSub;
        MoveDown.OnDown += MoweDownSub;
        MoveRight.OnDown += MoweRightSub;
    }

    private void OnDisable()
    {
        ZoomIn.OnDown -= ZoomInSub;
        ZoomOut.OnDown -= ZoomOutSub;
        RotateLeft.OnDown -= () => Rotate(-1);
        RotateRight.OnDown -= () => Rotate(1);
        MoveUp.OnDown -= MoweUpSub;
        MoveLeft.OnDown -= MoweLeftSub;
        MoveDown.OnDown -= MoweDownSub;
        MoveRight.OnDown -= MoweRightSub;
    }

    private void ZoomInSub()
    {
        if (Camera.main.orthographicSize > 2)
            Camera.main.orthographicSize -= _coeffZoom * _speed;
    }

    private void ZoomOutSub()
    {
        if (Camera.main.orthographicSize < 30)
            Camera.main.orthographicSize += _coeffZoom * _speed;
    }

    private void Rotate(float signDirection)
    {
        Vector3 eulers = new Vector3(0, Mathf.Sign(signDirection) * _coeffRotation * _speed, 0);

        _camera.Rotate(eulers, Space.World);
    }

    private void Update()
    {
        _angleRad = _camera.localEulerAngles * Mathf.Deg2Rad;
    }

    private void MoweUpSub()
    {
        NewPosition(Mathf.Sin(_angleRad.y), 0, Mathf.Cos(_angleRad.y));
    }

    private void MoweLeftSub()
    {
        _camera.position -= _camera.right * _coeffMove * _speed;
    }

    private void MoweDownSub()
    {
        NewPosition(-Mathf.Sin(_angleRad.y), 0, -Mathf.Cos(_angleRad.y));
    }

    private void MoweRightSub()
    {
        _camera.position += _camera.right * _coeffMove * _speed;
    }

    private void NewPosition(float x, float y, float z)
    {
        Vector3 offset = new Vector3(x, y, z);
        _camera.position = Vector3.Lerp(_camera.position, _camera.position + offset, _coeffMove * _speed);
        //_camera.position += offset * 5;
    }
}

