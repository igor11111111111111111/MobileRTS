using System.Collections.Generic;
using UnityEngine;

public class Logic : MonoBehaviour
{
    [HideInInspector] // all
    public MoveToUnit MoveToUnit;
    [HideInInspector]
    public FrightRun FrightRun;
    [HideInInspector]
    public FollowMouse FollowMouse;
    [HideInInspector]
    public SelfDefense SelfDefense;
    [HideInInspector]
    public ToDefensivePos ToDefensivePos;
    [HideInInspector]
    public Patrol Patrol;
    [HideInInspector]
    public FindDistributor FindDistributor;
    [HideInInspector] 
    public FindNearEnemy FindNearEnemy;

    [HideInInspector] // warrior
    public FightWithEnemy FightWithEnemy;

    [HideInInspector] // healer
    public FindNearWoundedFriend FindNearWoundedFriend;
    [HideInInspector]
    public HealFriend HealFriend;

    [HideInInspector] // necromancer
    public FindNearDead FindNearDead;
    [HideInInspector]
    public ResurrectDead ResurrectDead;

    [HideInInspector] // Archer
    public MoveToShootArea MoveToShootArea;
    [HideInInspector]
    public Aim Aim;
    [HideInInspector]
    public Shoot Shoot;

    protected List<State> _states;

    public Target Target => _target;
    protected Target _target;
    protected Unit _unit;
    protected StateMachine _stateMachine;

    protected virtual void Start()
    {
        _states = new List<State>();
        _target = new Target();
        _unit = GetComponent<Unit>();
        _stateMachine = new StateMachine();

        InitStates();
        Subscribe();
    }

    protected virtual void InitStates()
    {
        _states.Add(MoveToUnit = new MoveToUnit());
        _states.Add(FindDistributor = new FindDistributor());
        _states.Add(FrightRun = new FrightRun());
        _states.Add(FollowMouse = new FollowMouse());
        _states.Add(SelfDefense = new SelfDefense());
        _states.Add(ToDefensivePos = new ToDefensivePos());
        _states.Add(Patrol = new Patrol());
        _states.Add(FindNearEnemy = new FindNearEnemy());

        foreach (var state in _states)
        {
            state.Init(this, _unit, _target, _stateMachine);
        }
    }

    private void Subscribe()
    {
        _unit.OnDeath += () => Destroy(this);
        _unit.OnFollowMouse += () => _stateMachine.ChangeState(FollowMouse);
        _unit.OnSomeoneBeatsMe += () => _stateMachine.ChangeState(SelfDefense);
    }

    private void OnDestroy()
    {
        _unit.OnDeath -= () => Destroy(this);
        _unit.OnFollowMouse -= () => _stateMachine.ChangeState(FollowMouse);
        _unit.OnSomeoneBeatsMe -= () => _stateMachine.ChangeState(SelfDefense);
    }

    private void Update()
    {
        //if (/*_unit.Team == Enums.Team.Player*/_unit as Archer)
        //    Debug.Log(_unit + " " + _stateMachine.CurrentState);
        //Debug.Log(_unit +" "+_stateMachine.CurrentState/* + " " + Enemy.Unit + " " + Enemy.Unit.Exists + " " + _unit.Stand*/);

        _stateMachine.CurrentState.LogicUpdate();

        if (_unit.Stand == Enums.Stand.FrightRun && !_unit.FollowMouse)
        {
            _stateMachine.ChangeState(FrightRun);
        }
    }

    private void FixedUpdate()
    {
        _stateMachine.CurrentState.PhysicsUpdate();
    }
}