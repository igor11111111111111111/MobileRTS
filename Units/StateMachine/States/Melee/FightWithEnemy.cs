using System.Collections;
using UnityEngine;

public class FightWithEnemy : State 
{
    public override void Enter()
    {
        base.Enter();
        _delay = (_unit as IMelee).DelayAttack;
    }

    public override void CustomUpdate()
    {
        if (_target != null && _target.InContactArea(_unit))
        {
            _unit.transform.LookAt(_target.Unit.transform.position);

            (_logic as MeleeLogic).OnAttack?.Invoke();
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
}
