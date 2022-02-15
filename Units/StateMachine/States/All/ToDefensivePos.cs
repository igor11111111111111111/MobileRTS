using UnityEngine;

public class ToDefensivePos : State
{
    public override void Enter()
    {
        base.Enter();
        _delay = 5;
    }

    public override void CustomUpdate()
    {
        var pos = _unit.DefensivePosition;
        _unit.Agent.SetDestination(pos);

        if (Mathf.Round(Vector3.Distance(_unit.transform.position, _unit.DefensivePosition)) == 0)
        {
            _stateMachine.ChangeState(_logic.FindDistributor);
        }
    }
}
