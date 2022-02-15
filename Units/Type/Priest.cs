public class Priest : Unit, IHeal
{
    public int DelayHeal { get; set; }
    public float HealPower { get; set; }

    private void Start()
    {
        _classWarrior = Enums.ClassWarrior.Priest;
        _damage = 15f;
        _armor = 0f;
        _maxHealth = 200f;
        _radiusVision = 10f;
        _regenDelaySec = 3f;
        _expMurdererGet = 100f;
        CurrentHealth = _maxHealth;

        _stoppingDistanceToTarget = 5f;
        DelayHeal = 4 * 60;
        HealPower = 10f;
    }
}
