using UnityEngine;

public class FrightRun : State
{
    public override void Enter()
    {
        base.Enter();
        _delay = 5;
    }

    public override void CustomUpdate()
    {
        if (_unit.Stand == Enums.Stand.FrightRun &&
            _target != null &&
            _target.Unit != null &&
            _target.Unit.Team != _unit.Team &&
            _target.Unit.Exists &&
            !_unit.FollowMouse &&
            Vector3.Distance(_target.Unit.transform.position, _unit.transform.position) < _unit.FrightRunDistance)
        {
            var target = VectorExtensions.GetFrightRunDestination(_target.Unit, _unit);
            _unit.Agent.SetDestination(target);
        }
        else
        {
            _stateMachine.ChangeState(_logic.FindDistributor);
        }
    }
}
