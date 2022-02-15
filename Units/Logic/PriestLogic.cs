using UnityEngine;
using UnityEngine.Events;

public class PriestLogic : Logic
{
    [HideInInspector]
    public UnityAction OnHeal;
    public UnityAction OnInterruptAction;

    protected override void Start()
    {
        base.Start();

        _stateMachine.Initialize(FindNearWoundedFriend);
    }

    protected override void InitStates()
    {
        _states.Add(HealFriend = new HealFriend());
        _states.Add(FindNearWoundedFriend = new FindNearWoundedFriend());

        base.InitStates();
    }
}
