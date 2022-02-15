using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lord : Unit, IMelee
{
    public int DelayAttack { get; set; }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Lord;
        _damage = 30f;
        _armor = 10f;
        _maxHealth = 500f;
        _radiusVision = 10f;
        _regenDelaySec = 3f;
        _expMurdererGet = 100f;
        CurrentHealth = MaxHealth;

        _stoppingDistanceToTarget = 1.3f;
        DelayAttack = 70;
    }
}
