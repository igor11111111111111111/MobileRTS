using UnityEngine;

public class MoveToShootArea : State
{
    private int _deviations;
    private Vector3 _position;
    private Unit _targetUnit => _target.Unit;

    public override void Enter()
    {
        base.Enter();
        _delay = 5;

        _deviations = (_unit as IRanged).StoppingDistanceDeviations;

        if (_unit.Stand == Enums.Stand.Defensive)
        {
            _unit.DefensivePosition = _unit.transform.position;
        }
    }

    public override void CustomUpdate()
    {
        if (_target != null && _targetUnit != null &&
           (_unit.Stand == Enums.Stand.Aggressive || _unit.Stand == Enums.Stand.Defensive) &&
           (_target.Unit.Exists))
        {
            Move();
        }

        else if (_unit.Stand == Enums.Stand.Defensive)
        {
            _stateMachine.ChangeState(_logic.ToDefensivePos);
        }

        else
        {
            _stateMachine.ChangeState(_logic.FindDistributor);
        }
    }

    private void Move()
    {
        var distance = VectorExtensions.Distance(_unit, _targetUnit);

        if (distance > _unit.StoppingDistanceToTarget + _deviations)
        {
            _position = _targetUnit.transform.position;
        }

        else if (distance < _unit.StoppingDistanceToTarget - _deviations)
        {
            _position = VectorExtensions.GetFrightRunDestination(_targetUnit, _unit);
        }

        else
        {
            _position = _unit.transform.position;
            _stateMachine.ChangeState(_logic.Aim);
        }

        _unit.Agent.SetDestination(_position);
    }
}
