using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomRotateCameraPanel : MonoBehaviour
{
    public Button ZoomLeft;
    public Button ZoomRight;
    public Button RotateQ;
    public Button RotateE;

    public Button MoveW;
    public Button MoveA;
    public Button MoveS;
    public Button MoveD;

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
        _speed = 10;

        ZoomLeft.onClick.AddListener(ZoomLeftA);
        ZoomRight.onClick.AddListener(ZoomRightA);
        RotateQ.onClick.AddListener(RotateQA);
        RotateE.onClick.AddListener(RotateEA);

        MoveW.onClick.AddListener(MoweWA);
        MoveA.onClick.AddListener(MoweAA);
        MoveS.onClick.AddListener(MoweSA);
        MoveD.onClick.AddListener(MoweDA);
    }

    private void ZoomLeftA()
    {
        if (Camera.main.orthographicSize > 2)
            Camera.main.orthographicSize -= _coeffZoom * _speed;
    }

    private void ZoomRightA()
    {
        if (Camera.main.orthographicSize < 30)
            Camera.main.orthographicSize += _coeffZoom * _speed;
    }

    private void RotateQA()
    {
        Rotate(-1);
    }
    private void RotateEA()
    {
        Rotate(1);
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

    private void MoweWA()
    {
        NewPosition(Mathf.Sin(_angleRad.y), 0, Mathf.Cos(_angleRad.y));
    }

    private void MoweAA()
    {
        _camera.position -= _camera.right * _coeffMove * _speed;
    }

    private void MoweSA()
    {
        NewPosition(-Mathf.Sin(_angleRad.y), 0, -Mathf.Cos(_angleRad.y));
    }

    private void MoweDA()
    {
        _camera.position += _camera.right * _coeffMove * _speed;
    }

    private void NewPosition(float x, float y, float z)
    {
        Vector3 offset = new Vector3(x, y, z);
        _camera.position = Vector3.Lerp(_camera.position, _camera.position + offset, _coeffMove * _speed);
    }
}

