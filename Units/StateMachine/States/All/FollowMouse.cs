using UnityEngine;

public class FollowMouse : State
{
    private Vector3 _oldMousePosition;

    public override void Enter()
    {
        base.Enter();
        _delay = 5;
    }

    public override void CustomUpdate()
    {
        _unit.Agent.SetDestination(_unit.MousePosition);

        if (!_unit.FollowMouse || _unit.MousePosition == _unit.transform.position)
        {
            _stateMachine.ChangeState(_logic.FindDistributor);
        }
    }
}
