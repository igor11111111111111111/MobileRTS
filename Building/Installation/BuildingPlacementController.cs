using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildingPlacementController : MonoBehaviour
{
    public CustomButton RotateLeft;
    public CustomButton RotateRight;

    public CustomButton MoveUp;
    public CustomButton MoveLeft;
    public CustomButton MoveDown;
    public CustomButton MoveRight;

    public Button Allow;
    public Button Deny;

    [SerializeField]
    private GameObject _body;
    private PlacedEntity _building {
        get
        {
            return BuildingGhost.Instance.CurrentEntity;
        }
        set
        {
            BuildingGhost.Instance.CurrentEntity = value;
        }
    }
    private Camera _mainCamera;
    private PurchaseBuilding _purchase = new PurchaseBuilding();
    private float _angleCamera => _mainCamera.transform.localEulerAngles.y * Mathf.Deg2Rad;
    private const float _speedMove = 0.25f;
    private const float _speedRotate = 1.5f;

    private void Start()
    {
        _mainCamera = Camera.main;
        _body.SetActive(false);
        _purchase.Init();
    }

    private void OnEnable()
    {
        RotateLeft.OnDown += () => Rotate(-1);
        RotateRight.OnDown += () => Rotate(1);

        MoveUp.OnDown += () => Move(Mathf.Sin(_angleCamera), Mathf.Cos(_angleCamera));
        MoveDown.OnDown += () => Move(-Mathf.Sin(_angleCamera), -Mathf.Cos(_angleCamera));
        MoveRight.OnDown += () => Move(Mathf.Cos(_angleCamera), -Mathf.Sin(_angleCamera));
        MoveLeft.OnDown += () => Move(-Mathf.Cos(_angleCamera), Mathf.Sin(_angleCamera));

        Allow.onClick.AddListener(AllowSub);
        Deny.onClick.AddListener(DenySub);
    }

    private void OnDisable()
    {
        RotateLeft.OnDown -= () => Rotate(-1);
        RotateRight.OnDown -= () => Rotate(1);

        MoveUp.OnDown -= () => Move(Mathf.Sin(_angleCamera), Mathf.Cos(_angleCamera));
        MoveDown.OnDown -= () => Move(-Mathf.Sin(_angleCamera), -Mathf.Cos(_angleCamera));
        MoveRight.OnDown -= () => Move(Mathf.Cos(_angleCamera), -Mathf.Sin(_angleCamera));
        MoveLeft.OnDown -= () => Move(-Mathf.Cos(_angleCamera), Mathf.Sin(_angleCamera));

        Allow.onClick.RemoveListener(AllowSub);
        Deny.onClick.RemoveListener(DenySub);
    }

    private void Move(float x, float z)
    {
        _building.MoveView(new Vector3(x, 0, z) * _speedMove);
    }

    private void Rotate(float signDirection)
    {
        var angle = new Vector3(0, Mathf.Sign(signDirection), 0);
        _building.RotateView(angle * _speedRotate);
    }

    private void AllowSub()
    {
        if (_building == null || !_purchase.TryPurchase()) return;

        if (_building.TryPlace())
        {
            EfficiencyPanel.Instance.BodyActive(false);
            _body.SetActive(false);
        }
    }

    private void DenySub() 
    {
        EfficiencyPanel.Instance.BodyActive(false);
        BuildingGhost.Instance.Destroy();
        _body.SetActive(false);
    }
}
