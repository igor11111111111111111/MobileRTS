using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAnimator : UnitAnimator
{
    private RangedLogic _rangedLogic;

    protected override void Start()
    {
        base.Start();

        _rangedLogic = _logic as RangedLogic;
        _rangedLogic.OnAttack += Attack;
        _rangedLogic.OnInterruptAction += InterruptAttack;
    }

    private void OnDestroy()
    {
        _rangedLogic.OnAttack -= Attack;
        _rangedLogic.OnInterruptAction -= InterruptAttack;
    }

    private void Attack()
    {
        _animator.SetTrigger("IsAttack");
    }

    private void InterruptAttack()
    {
        _animator.SetTrigger("IsInterruptAttack");
    }

    public void AnimationEventAttack()
    {
        var target = _logic.Target.Unit;
        if (target == null) return;

        StackArrows
            .Pop()
            .GetComponent<Arrow>()
            .SetStartSettings(_unit, target);
    }
}
