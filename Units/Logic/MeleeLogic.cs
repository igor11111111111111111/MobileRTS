using UnityEngine;
using UnityEngine.Events;

public class MeleeLogic : WarriorLogic
{
    protected override void Start()
    {
        base.Start();
        _stateMachine.Initialize(FindDistributor);
    }

    protected override void InitStates()
    {
        _states.Add(FightWithEnemy = new FightWithEnemy());

        base.InitStates();
    }
}
