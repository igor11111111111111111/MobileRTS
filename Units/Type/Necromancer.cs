using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : Unit, IResurrect
{
    public int DelayResurrect { get; set; }
    [SerializeField]
    private GameObject _resurrectedUndead;
    public GameObject ResurrectedUndead
    {
        get
        {
            return _resurrectedUndead;
        }
        set { }
    }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Necromancer;
        _damage = 15f;
        _armor = 0f;
        _maxHealth = 150f;
        _radiusVision = 20f;
        _regenDelaySec = 1.5f;
        _expMurdererGet = 200f;
        CurrentHealth = _maxHealth;

        _stoppingDistanceToTarget = 2f;
        DelayResurrect = 5 * 60;
    }
}