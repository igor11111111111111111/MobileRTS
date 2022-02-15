using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerAnimator : UnitAnimator
{
    private NecromancerLogic _necrLogic;

    protected override void Start()
    {
        base.Start();

        _necrLogic = _logic as NecromancerLogic;
        _necrLogic.OnResurrect += Resurrect;
        _necrLogic.OnInterruptAction += InterruptResurrect;
    }

    private void OnDestroy()
    {
        _necrLogic.OnResurrect -= Resurrect;
        _necrLogic.OnInterruptAction -= InterruptResurrect;
    }

    private void Resurrect()
    {
        _animator.SetTrigger("IsResurrect");
        _animator.SetInteger("ResurrectIndex", Random.Range(1, 3));
    }

    private void InterruptResurrect()
    {
        _animator.SetTrigger("IsInterruptResurrect");
    }

    public void AnimationEventResurrect()
    {
        var targetUnit = _necrLogic.Target.Unit;
        if (targetUnit != null)
        {
            var necr = _unit as Necromancer;
            var undead = Instantiate(necr.ResurrectedUndead, targetUnit.transform.position, Quaternion.identity);
            undead.GetComponent<Unit>().Team = _unit.Team;
            Destroy(targetUnit.gameObject);
        }
    }
}
