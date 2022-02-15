using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Unit, IRanged
{
    public int DelayAttack { get; set; }
    public Vector3 PreShotDistance { get; set; }
    public int StoppingDistanceDeviations { get; set; }
    [SerializeField]
    private Transform _spawnedAmmoTransform;
    public Transform SpawnedAmmoTransform
    {
        get
        {
            return _spawnedAmmoTransform;
        }
        set { }
    }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Archer;
        _damage = 10f;
        _armor = 0f;
        _maxHealth = 150f;
        _radiusVision = 20f;
        _regenDelaySec = 1.5f;
        _expMurdererGet = 200f;
        CurrentHealth = _maxHealth;

        _stoppingDistanceToTarget = 8f;
        DelayAttack = 90;
        StoppingDistanceDeviations = 2;
    }
}
