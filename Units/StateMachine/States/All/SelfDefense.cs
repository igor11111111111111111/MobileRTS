using UnityEngine;

public class SelfDefense : State
{
    public override void Enter()
    {
        base.Enter();

        _unit.FollowMouse = false;

        if (_unit is IWarrior)
        {
            if (_unit.Stand == Enums.Stand.Passive)
            {
                _unit.Stand = Enums.Stand.Defensive;
            }

            _stateMachine.ChangeState(_logic.FindDistributor);
        }

        else if (_unit is ISupport)
        {
            _unit.Stand = Enums.Stand.FrightRun;
        }
    }
}
