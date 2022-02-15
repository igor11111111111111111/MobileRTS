using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestAnimator : UnitAnimator
{
    private PriestLogic _priestLogic;

    protected override void Start()
    {
        base.Start();

        _priestLogic = _logic as PriestLogic;
        _priestLogic.OnHeal += Heal;
        _priestLogic.OnInterruptAction += InterruptHeal;
    }

    private void OnDestroy()
    {
        _priestLogic.OnHeal -= Heal;
        _priestLogic.OnInterruptAction -= InterruptHeal;
    }

    private void Heal()
    {
        _animator.SetTrigger("IsHeal");
        _animator.SetInteger("HealIndex", Random.Range(1, 3));
    }

    private void InterruptHeal()
    {
        _animator.SetTrigger("IsInterruptHeal");
    }

    public void AnimationEventHeal()
    {
        if (_priestLogic.Target.Unit != null && _unit.Exists)
        {
            _priestLogic.Target.Unit.CurrentHealth += (_unit as Priest).HealPower;
        }
    }
}
