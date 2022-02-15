using UnityEngine;
using System.Linq;

public class FindNearDead : State 
{
    public override void CustomUpdate()
    {
        if (_unit.Stand == Enums.Stand.Passive) return;

        Collider[] allCollider = Physics.OverlapSphere(_unit.transform.position, _unit.RadiusVision);

        var allDead = allCollider
        .Where(col =>
        {
            var diedGO = col.gameObject;
            var diedUnit = diedGO.GetComponent<Unit>();

            if (diedGO != _unit.gameObject &&
                diedUnit?.Exists == false)
            {
                return true;
            }

            return false;
        })
        .ToArray();

        var diedCollider = allDead
            .OrderBy(d => Vector3.Distance(_unit.transform.position, d.transform.position))
            .FirstOrDefault();

        var DiedUnit = diedCollider?.GetComponent<Unit>();

        if (DiedUnit != null)
        {
            _target.Init(DiedUnit, diedCollider);

            _stateMachine.ChangeState(_logic.MoveToUnit);
        }
    }
}
