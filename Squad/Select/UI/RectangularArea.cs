using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularArea : MonoBehaviour
{
    [SerializeField]
    private GUISkin _skin;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private bool _draw = false;
     
    private void Start()
    {
        // Left 
        PositionOnGesture.OnSelectDown += (pos) =>
        {
            _startPosition = _endPosition = pos;
        };

        PositionOnGesture.OnSelect += (pos) =>
        {
            _endPosition = pos;

            _draw = Vector2.Distance(_startPosition, _endPosition) > 15 ? true : false;
        };

        PositionOnGesture.OnSelectUp += (pos) =>
        {
            _draw = false;
        };
    }

    void OnGUI()
    {
        GUI.skin = _skin;

        if (_draw)
        {
            var width = Mathf.Max(_endPosition.x, _startPosition.x) - Mathf.Min(_endPosition.x, _startPosition.x);
            var height = Mathf.Max(_endPosition.y, _startPosition.y) - Mathf.Min(_endPosition.y, _startPosition.y);
            var rect = new Rect(Mathf.Min(_endPosition.x, _startPosition.x), Screen.height - Mathf.Max(_endPosition.y, _startPosition.y), width, height);
            GUI.Box(rect, "");
        }
    }
}