using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirectionArrow : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    private void Start()
    {
        // right
        PositionOnGesture.OnMoveDown += OnMouseDownHandler;
        PositionOnGesture.OnMoveUp += OnMouseUpHandler;
        PositionOnGesture.OnMove += OnMouseHandler;
    }

    private void OnMouseDownHandler(Vector3 startPosition)
    {
        _lineRenderer.SetPosition(0, new Vector3(startPosition.x, 0.1f, startPosition.z));
    }

    private void OnMouseUpHandler(Vector3 pos, Vector3 pos1)
    {
        _lineRenderer.SetPosition(0, Vector3.zero);
        _lineRenderer.SetPosition(1, Vector3.zero);
    }

    private void OnMouseHandler(Vector3 endPosition)
    {
        _lineRenderer.SetPosition(1, new Vector3(endPosition.x, 0.1f, endPosition.z));
    }
}
