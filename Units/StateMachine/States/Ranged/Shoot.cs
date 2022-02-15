using UnityEngine;

public class Shoot : State
{
    private IRanged _ranged;
    private RangedLogic _rangedLogic;

    public override void Enter()
    {
        _ranged = (_unit as IRanged);

        base.Enter();
        _delay = _ranged.DelayAttack;
        _time = 0;

        _rangedLogic = (_logic as RangedLogic);

        _rangedLogic.OnAttack?.Invoke();
    }

    public override void CustomUpdate()
    {
        _stateMachine.ChangeState(_logic.Aim);
    }

    public override void LogicUpdate()
    {
        if (_target.Unit == null) return;

        _unit.transform.LookAt(_target.Unit.transform.position + _ranged.PreShotDistance);
    }

    public override void Exit()
    {
        if (_stateMachine.NextState == _logic.FollowMouse ||
            _stateMachine.NextState == _logic.FrightRun)
        {
            _rangedLogic.OnInterruptAction?.Invoke();
        }
    }
}

