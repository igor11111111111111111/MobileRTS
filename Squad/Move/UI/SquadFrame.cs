using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadFrame : MonoBehaviour
{
    [SerializeField]
    private GameObject _frame;
    [SerializeField]
    private GameObjectsSO _selectedUnits;
    private Vector3 _startPosition;

    private void Start()
    {
        // right
        PositionOnGesture.OnMoveDown += InitStartPosition;
        PositionOnGesture.OnMove += Draw;
        PositionOnGesture.OnMoveUp += TurnOff;
    }

    private void InitStartPosition(Vector3 startPosition)
    {
        _startPosition = startPosition;
    }

    private void Draw(Vector3 endPosition)
    {
        if (_selectedUnits.List.Count == 0)
        {
            return;
        }

        if (!_frame.gameObject.activeInHierarchy)
        {
            _frame.SetActive(true);
        }

        SquadFormationMath.SetFrameTransform(_startPosition, endPosition, _selectedUnits, _frame.transform);
    }

    private void TurnOff(Vector3 vector, Vector3 vector2)
    {
        _frame.SetActive(false);
    }
}
