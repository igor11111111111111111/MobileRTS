using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class Unit : MonoBehaviour 
{
    #region Data
    public event UnityAction OnSomeoneBeatsMe;
    public event UnityAction OnDeath;
    public UnitPresenterOnButton Presenter; //! opened
    public UnityAction OnFollowMouse;
    public Enums.Team Team;
    public Enums.Stand Stand;
    [HideInInspector]
    public bool FollowMouse;
    [HideInInspector]
    public Vector3 MousePosition;
    [HideInInspector]
    public Vector3 DefensivePosition;
    public float Damage => _damage;
    protected float _damage;
    public float Armor => _armor;
    protected float _armor;
    public float MaxHealth => _maxHealth;
    protected float _maxHealth;
    public float CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                OnDeath.Invoke();
            }
            else if (CurrentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
    private float _currentHealth;
    public Enums.ClassWarrior ClassWarrior => _classWarrior;
    protected Enums.ClassWarrior _classWarrior;
    public float RadiusVision => _radiusVision;
    protected float _radiusVision;
    public Sprite Portrait => _portrait;
    [SerializeField]
    protected Sprite _portrait;
    public float ExpMurdererGet => _expMurdererGet;
    protected float _expMurdererGet;
    public float RegenDelaySec => _regenDelaySec;
    protected float _regenDelaySec;
    public float Expirience
    {
        get
        {
            return _expirience;
        }
        set
        {
            _expirience = value;
            ExpirienceLogic.CheckLevelChange(this);
        }
    }
    private float _expirience;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
            InfluenceOfLevel();
        }
    }
    private int _level;
    public float StoppingDistanceToTarget => _stoppingDistanceToTarget;
    protected float _stoppingDistanceToTarget;
    public float NormalizedHealth => CurrentHealth / MaxHealth;
    public bool Exists { get; private set; } = true;
    public NavMeshAgent Agent { get; private set; }
    public float FrightRunDistance { get; private set; } = 10f;
    private Unit _damager;
    public Fixtures Fixtures { get; private set; }
    #endregion

    #region Methods

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Regeneration());
        OnDeath += Die;
    }

    private void OnDestroy()
    {
        OnDeath -= Die;
    }

    public void InitFixtures(Fixtures fixtures)
    {
        Fixtures = fixtures;
    }

    public void ApplyDamage(Unit damager)
    {
        if ((this is IMelee && Stand == Enums.Stand.Passive || FollowMouse) || this is ISupport)
        {
            OnSomeoneBeatsMe?.Invoke();
        }
        
        _damager = damager;
        CurrentHealth -= damager.Damage * (1 - Armor / 100);
    }

    private void InfluenceOfLevel()
    {
        _maxHealth += (Level - 1) * 5;
        _damage += (Level - 1) * 5;
        _armor += (Level - 1) * 2;
    }

    private IEnumerator Regeneration()
    {
        while (Exists)
        {
            CurrentHealth ++;
            yield return new WaitForSeconds(RegenDelaySec);
        }
    }

    protected virtual void Die()
    {
        ExpirienceLogic.TryRewardMurderer(_damager, this);
        Exists = false;
    }

    //protected virtual void Die()
    //{
    //    ExpirienceLogic.TryRewardMurderer(_damager, this);
    //    Exists = false;
    //    Fixtures.SetActive(false);
    //    OnDeath?.Invoke();
    //}
    #endregion
}