using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquadFormationMath : MonoBehaviour
{
    private static float _minArrowLength = 0.5f;
    private static float _maxArrowLength = 9;
    private static float _distBetwUnit = 1.5f;

    private static int _numberUnits;
    private static int _column;
    private static int _row;

    private static Vector3 _startPosition;
    private static Vector3 _endPosition;

    private static List<NavMeshAgent> agents;
    private static List<Unit> units;

    public static void SetUnitsPositions(Vector3 startPosition, Vector3 endPosition, GameObjectsSO selectedUnits)
    {
        Init(startPosition, endPosition, selectedUnits);

        var angleRad = GetAngleRad();
        int unit = 0;
        for (int z = 0; z < _row; z++)
        {
            for (int x = 0; x < _column; x++)
            {
                if (unit == _numberUnits) break;

                var individualPos = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)) * (unit - z * _column) * _distBetwUnit + GetDistBetwLines(angleRad) * z;
                var finalPosition = individualPos + startPosition + CenterSquad();

                units[unit].MousePosition = finalPosition;
                units[unit].FollowMouse = true;
                units[unit].OnFollowMouse?.Invoke();

                unit++;
            } 
        }
    }

    private static Vector3 CenterSquad()
    {
        var columnDist = new Vector3(Mathf.Cos(GetAngleRad()), 0, Mathf.Sin(GetAngleRad())) * (_column - 1);
        var rowDist = Click() ? new Vector3(Mathf.Sin(GetAngleRad()), 0, Mathf.Cos(GetAngleRad())) * (_row - 1)
    : Vector3.zero;
        return (rowDist - columnDist) *_distBetwUnit / 2;
    }

    public static void SetFrameTransform(Vector3 startPosition, Vector3 endPosition, GameObjectsSO selectedUnits, Transform transform)
    {
        Init(startPosition, endPosition, selectedUnits);

        transform.localScale = Click() ? Vector3.zero : new Vector3(_row, 0.3f, _column) * _distBetwUnit;
        transform.eulerAngles = new Vector3(0, -GetAngleRad() * Mathf.Rad2Deg - 90, 0);
        transform.position = startPosition + GetDistBetwLines(GetAngleRad()) * (_row - 1) / 2;
    }

    private static void Init(Vector3 startPosition, Vector3 endPosition, GameObjectsSO selectedUnits)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;

        _numberUnits = selectedUnits.List.Count;
        _column = GetColumn();
        _row = GetRow();

        agents = selectedUnits.List.ConvertTo<NavMeshAgent>();
        units = selectedUnits.List.ConvertTo<Unit>();
    } 

    private static bool Click()
    {
        return Vector3.Distance(_startPosition, _endPosition) <= _minArrowLength;
    }

    private static float GetDistance()
    {
        var distance = Vector3.Distance(_startPosition, _endPosition);
        distance = distance > _maxArrowLength ? _maxArrowLength : distance;
        distance = distance <= _minArrowLength ? _maxArrowLength / 2 : distance;

        return distance;
    }

    private static float GetAngleRad()
    {
        int sign = _startPosition.z < _endPosition.z ? 1 : -1;
        var angleVector = Vector3.Angle(_endPosition - _startPosition, new Vector3(1, 0, 0));
        float angleDeg = angleVector * sign + 90;
        float angleRad = angleDeg * Mathf.Deg2Rad;

        return angleRad;
    }

    private static Vector3 GetDistBetwLines(float angleRad)
    {
        return new Vector3(-Mathf.Sin(angleRad), 0, Mathf.Cos(angleRad)) * _distBetwUnit;
    }

    private static int GetColumn()
    {
        return (int)Math.Ceiling((Mathf.Pow(_numberUnits, (-GetDistance() + _maxArrowLength) * 0.11f)));
    }

    private static int GetRow()
    {
        return (int)Math.Ceiling(_numberUnits / (double)_column);
    }

    public static void ReachedMousePosition()
    {
        if (units == null) return;

        foreach (Unit unit in units)
        {
            if (unit == null) return;

            if (Mathf.Round(Vector3.Distance(unit.transform.position, unit.MousePosition)) == 0)
            {
                unit.FollowMouse = false;
            }
        }
    }
}

