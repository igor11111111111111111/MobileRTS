using UnityEngine;

public class FindDistributor : State 
{
    public override void Enter()
    {
        if (_unit is IWarrior || (_unit is ISupport && _unit.Stand == Enums.Stand.FrightRun))
        {
            _stateMachine.ChangeState(_logic.FindNearEnemy);
        }

        else if (_unit is IHeal)
        {
            _stateMachine.ChangeState(_logic.FindNearWoundedFriend);
        }

        else if (_unit is IResurrect)
        {
            _stateMachine.ChangeState(_logic.FindNearDead);
        }
    }
}
