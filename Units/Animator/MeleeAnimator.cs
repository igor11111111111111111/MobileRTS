using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAnimator : UnitAnimator
{
    private MeleeLogic _meleeLogic;

    protected override void Start()
    {
        base.Start();

        _meleeLogic = (_logic as MeleeLogic);
        _meleeLogic.OnAttack += Attack;
    }

    private void OnDestroy()
    {
        _meleeLogic.OnAttack -= Attack;
    }

    private void Attack()
    {
        _animator.SetTrigger("IsAttack");
        _animator.SetInteger("AttackIndex", Random.Range(1, 3));
    }

    public void AnimationEventAttack()
    {
        if (_meleeLogic.Target.Unit != null && _unit.Exists)
            _meleeLogic.Target.Unit.ApplyDamage(_unit);
    }
}