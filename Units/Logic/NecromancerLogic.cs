using UnityEngine;
using UnityEngine.Events;

public class NecromancerLogic : Logic
{
    [HideInInspector]
    public UnityAction OnResurrect;
    public UnityAction OnInterruptAction;

    protected override void Start()
    {
        base.Start();
        _stateMachine.Initialize(FindNearDead);
    }

    protected override void InitStates()
    {
        _states.Add(FindNearDead = new FindNearDead());
        _states.Add(ResurrectDead = new ResurrectDead());

        base.InitStates();
    }
}
