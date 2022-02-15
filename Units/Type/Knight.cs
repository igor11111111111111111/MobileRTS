public class Knight : Unit, IMelee
{
    public int DelayAttack { get; set; }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Knight;
        _damage = 15f;
        _armor = 0f;
        _maxHealth = 200f;
        _radiusVision = 10f;
        _regenDelaySec = 3f;
        _expMurdererGet = 100f;
        CurrentHealth = MaxHealth;

        _stoppingDistanceToTarget = 1.3f;
        DelayAttack = 70;
    }
}
