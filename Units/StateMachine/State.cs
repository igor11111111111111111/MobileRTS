using UnityEngine;
using UnityEngine.AI;

public abstract class State  
{
    protected Logic _logic;
    protected Unit _unit;
    protected Target _target;
    protected StateMachine _stateMachine;
    protected int _time;
    protected int _delay; // 60 = one seconds;

    public void Init(Logic logic, Unit unit, Target target, StateMachine stateMachine)
    {
        _logic = logic;
        _unit = unit;
        _target = target;
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        _time = -1;
        _delay = 60;
    }

    public virtual void HandleInput()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        _time++;
        if (_time % _delay == 0)
        {
            CustomUpdate();
        }
    }

    public virtual void CustomUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}
