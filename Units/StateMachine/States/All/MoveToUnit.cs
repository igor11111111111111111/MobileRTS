using UnityEngine;

public class MoveToUnit : State
{ 
    public override void Enter()
    {
        base.Enter();
        _delay = 5;
        if (_unit.Stand == Enums.Stand.Defensive)
        {
            _unit.DefensivePosition = _unit.transform.position;
        }
    }

    public override void CustomUpdate()
    {
        if (_target != null && _target.Unit != null &&
            (_unit.Stand == Enums.Stand.Aggressive || _unit.Stand == Enums.Stand.Defensive) && 
            (_target.Unit.Exists || (!_target.Unit.Exists && _unit is IResurrect)))
        {
            var pos = _target.Unit.transform.position;
            _unit.Agent.SetDestination(pos);
        }

        else if (_unit.Stand == Enums.Stand.Defensive)
        {
            _stateMachine.ChangeState(_logic.ToDefensivePos);
        }

        else
        {
            _stateMachine.ChangeState(_logic.FindDistributor);
        }

        if (_target.InContactArea(_unit))
        {
            if (_unit is IMelee)
            {
                _stateMachine.ChangeState(_logic.FightWithEnemy);
            }

            else if(_unit is IHeal)
            {
                _stateMachine.ChangeState(_logic.HealFriend);
            }

            else if (_unit is IResurrect)
            {
                _stateMachine.ChangeState(_logic.ResurrectDead);
            }
        }
    }

    public override void Exit()
    {
        _unit.Agent.SetDestination(_unit.transform.position);
    }
}
