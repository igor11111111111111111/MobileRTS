using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordAnimator : MeleeAnimator
{
    protected override void Death()
    {
        _animator.SetTrigger("IsDeath");

        _unit.OnDeath -= Death;
    }
}
