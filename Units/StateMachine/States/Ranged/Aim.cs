using UnityEngine;

public class Aim : State
{
    private Vector3 _oldPos;
    private Vector3 _newPos;
    private const float _coeffRestrictions = 6f;
    private const float _coeffOrder = 100;
    private Transform _targetTransform => _target.Unit.transform;

    public override void Enter()
    {
        base.Enter();
        _delay = 1;

        if (_target != null && _target.InContactArea(_unit))
        {
            _oldPos = _targetTransform.position;
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

    private void SetPreShotDistance()
    {
        _newPos = _targetTransform.position;
        var direction = (_newPos - _oldPos) * _coeffOrder;

        Vector3 distance = Vector3.zero;
        distance.x = direction.x > _coeffRestrictions ? _coeffRestrictions : direction.x;
        distance.x = direction.x < -_coeffRestrictions ? -_coeffRestrictions : direction.x;
        distance.z = direction.z > _coeffRestrictions ? _coeffRestrictions : direction.z;
        distance.z = direction.z < -_coeffRestrictions ? -_coeffRestrictions : direction.z;

        distance /= _coeffRestrictions;

        (_unit as IRanged).PreShotDistance = distance;
    }
    
    public override void CustomUpdate()
    {
        SetPreShotDistance();
        _stateMachine.ChangeState(_logic.Shoot);
    }
}

