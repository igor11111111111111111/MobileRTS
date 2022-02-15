using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using System;

public class SquadPosition : MonoBehaviour
{
    [SerializeField]
    private GameObjectsSO _selectedUnits;

    private void Start() 
    {
        // right
        PositionOnGesture.OnMoveUp += (startPos, endPos) => 
        {
            SquadFormationMath.SetUnitsPositions(startPos, endPos, _selectedUnits);
        };

        InvokeRepeating("CustomUpdate", 0, 1);
    }

    private void CustomUpdate()
    {
        SquadFormationMath.ReachedMousePosition();
    }
}
