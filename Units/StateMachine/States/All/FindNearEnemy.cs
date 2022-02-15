using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class FindNearEnemy : State
{
    private List<int> _friends;

    public override void Enter()
    {
        base.Enter();
        _delay = 60 * 4;
        _friends = new List<int>();
    }

    public override void CustomUpdate()
    {
        if (_unit.Stand == Enums.Stand.Passive) return;
        Collider[] allCollider = Physics.OverlapSphere(_unit.transform.position, _unit.RadiusVision);
        //Debug.Log("all " + allCollider.Length);
        var allEnemy = allCollider
        .Where(col =>
        {
            var findedGo = col.gameObject;
            if (_friends.Contains(findedGo.GetInstanceID()))//
            {
                return false;
            }//
            var findedUnit = findedGo.GetComponent<Unit>();

            if (findedUnit?.Team == _unit.Team)//
            {
                //Debug.Log("da");
                _friends.Add(findedGo.GetInstanceID());
            }//

            if (findedGo != _unit.gameObject &&
                findedUnit?.Exists == true &&
                findedUnit?.Team != _unit.Team)
            {
                return true;
            }
            return false;
        })
        .ToArray();
        var enemyCollider = allEnemy
            .OrderBy(t => Vector3.Distance(_unit.transform.position, t.transform.position))
            .FirstOrDefault();

        var EnemyUnit = enemyCollider?.GetComponent<Unit>();

        if (EnemyUnit != null)
        {
            _target.Init(EnemyUnit, enemyCollider);

            if (_unit is IMelee)
            {
                _stateMachine.ChangeState(_logic.MoveToUnit);
            }

            else if (_unit is IRanged)
            {
                _stateMachine.ChangeState(_logic.MoveToShootArea);
            }

            else if (_unit is ISupport)
            {
                _stateMachine.ChangeState(_logic.FrightRun);
            }
        }
    }
}
