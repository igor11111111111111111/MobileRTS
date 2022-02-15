using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Positions
{
    public Vector3 _сurrentPosition => _positions[_index];
    private List<Vector3> _positions;
    private int _index = 0;

    public Positions(List<Vector3> positions)
    {
        _positions = positions;
    }

    public void Update(Unit unit)
    {
        if (Mathf.Round(Vector3.Distance(unit.transform.position, _сurrentPosition)) == 0)
        {
            Next();
            SetDestination(unit);
        }
    }

    public void Next()
    {
        if (_index == _positions.Count - 1)
        {
            _index = 0;
        }
        else
        {
            _index++;
        }
    }

    public void SetDestination(Unit unit)
    {
        unit.Agent.SetDestination(_сurrentPosition);
    }
}

public class Patrol : FindNearEnemy
{
    private Positions _position = new Positions(new List<Vector3>()
    {
        new Vector3(0, 0, 0),
        new Vector3(10, 0, 0),
        new Vector3(10, 0, 10),
        new Vector3(0, 0, 10),
    });

    public override void Enter()
    {
        base.Enter();
        _position.SetDestination(_unit);
    }

    public override void LogicUpdate()
    {
        _position.Update(_unit);
    }
}
