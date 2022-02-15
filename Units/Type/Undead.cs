using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : Unit, IMelee
{
    public int DelayAttack { get; set; }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Undead;
        _damage = 10f;
        _armor = 0f;
        _maxHealth = 70f;
        _radiusVision = 10f;
        _regenDelaySec = 1.5f;
        _expMurdererGet = 50f;
        CurrentHealth = _maxHealth;

        _stoppingDistanceToTarget = 1.3f;
        DelayAttack = 80;
    }

    protected override void Die()
    {
        base.Die();
        Destroy(this);
    }
}