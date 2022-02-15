using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhysicsRaycasterExtension : MonoBehaviour
{
    public static PhysicsRaycasterExtension Instance;
    private LayerMask _defaultMask;
    private PhysicsRaycaster _raycast;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void Start()
    {
        _raycast = GetComponent<PhysicsRaycaster>();
        _defaultMask = _raycast.eventMask;
    }

    public void SetStartMask()
    {
        _raycast.eventMask = _defaultMask;
    }

    public void TurnOffMask(string name)
    {
        int layer = LayerMask.NameToLayer(name);

        if (layer == -1) throw new System.Exception("Invalid LayerMask");

        _raycast.eventMask = _defaultMask & ~(1 << layer);
    }
}