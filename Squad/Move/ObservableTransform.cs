using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableTransform : MonoBehaviour 
{
    public event Action<Transform> OnChangePosition;
    private Vector3 _lastPose;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _lastPose = _transform.position;
    }

    private void Update()
    {
        if(_transform.position != _lastPose)
        {
            if(OnChangePosition != null)
            {
                OnChangePosition.Invoke(_transform);
            }
        }

        _lastPose = _transform.position;
    }
}
