using UnityEngine;

public class ResurrectDead : State
{
    private NecromancerLogic _necrLogic;

    public override void Enter()
    {
        base.Enter();
        _delay = (_unit as IResurrect).DelayResurrect;

        _necrLogic = (_logic as NecromancerLogic);
    }

    public override void CustomUpdate()
    {
        if (ConditionsResurrectMet())
        {
            _unit.transform.LookAt(_target.Unit.transform.position);
            _necrLogic.OnResurrect?.Invoke();
        }
    }

    public override void LogicUpdate()
    {
        if (_unit.Stand == Enums.Stand.Passive)
        {
            _stateMachine.ChangeState(_logic.FindNearDead);
        }

        if (ConditionsResurrectMet())
        {
        }

        else if (_unit.Stand == Enums.Stand.Defensive)
        {
            _stateMachine.ChangeState(_logic.ToDefensivePos);
        }

        else
        {
            _stateMachine.ChangeState(_logic.FindNearDead);
        }
    }

    public override void Exit()
    {
        if (_stateMachine.NextState == _logic.FollowMouse ||
            _stateMachine.NextState == _logic.FrightRun)
        {
            _necrLogic.OnInterruptAction?.Invoke();
        }
    }

    private bool ConditionsResurrectMet()
    {
        if (_target != null &&
            _target.InContactArea(_unit))
        {
            return true;
        }

        return false;
    }
}
