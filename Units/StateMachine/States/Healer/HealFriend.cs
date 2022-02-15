using UnityEngine;

public class HealFriend : State
{
    private PriestLogic _priestLogic;

     public override void Enter()
    {
        base.Enter();
        _delay = (_unit as IHeal).DelayHeal;

        _priestLogic = (_logic as PriestLogic);
    }

    public override void CustomUpdate()
    {
        if (ConditionsHealMet())
        {
            _priestLogic.OnHeal?.Invoke();
        }
    }

    public override void LogicUpdate()
    {
        if (_unit.Stand == Enums.Stand.Passive)
        {
            _stateMachine.ChangeState(_logic.FindNearWoundedFriend);
        }

        if (ConditionsHealMet())
        {
            _unit.transform.LookAt(_target.Unit.transform.position);
        }

        else if (_unit.Stand == Enums.Stand.Defensive)
        {
            _stateMachine.ChangeState(_logic.ToDefensivePos);
        }

        else
        {
            _stateMachine.ChangeState(_logic.FindNearWoundedFriend);
        }
    }

    public override void Exit()
    {
        if (_stateMachine.NextState == _logic.FollowMouse || 
            _stateMachine.NextState == _logic.FrightRun)
        {
            _priestLogic.OnInterruptAction?.Invoke();
        }
    }

    private bool ConditionsHealMet()
    {
        if (_target != null &&
            _target.InContactArea(_unit) &&
            _target.Unit.NormalizedHealth != 1)
        {
            return true;
        }

        return false;
    }
}
