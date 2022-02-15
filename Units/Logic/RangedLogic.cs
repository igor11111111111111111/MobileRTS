using UnityEngine;
using UnityEngine.Events;

public class RangedLogic : WarriorLogic
{
    public UnityAction OnInterruptAction;

    protected override void Start()
    {
        base.Start();

        _stateMachine.Initialize(FindNearEnemy);
    }

    protected override void InitStates()
    {
        _states.Add(MoveToShootArea = new MoveToShootArea());
        _states.Add(Aim = new Aim());
        _states.Add(Shoot = new Shoot());

        base.InitStates();
    }
}
