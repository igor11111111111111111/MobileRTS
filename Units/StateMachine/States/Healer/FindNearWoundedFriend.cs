using UnityEngine;
using System.Linq;

public class FindNearWoundedFriend : State
{ 
    public override void CustomUpdate()
    {
        if (_unit.Stand == Enums.Stand.Passive) return;

        Collider[] allCollider = Physics.OverlapSphere(_unit.transform.position, _unit.RadiusVision);

        var allFriends = allCollider
        .Where(col =>
        {
            var friendGO = col.gameObject;
            var friendUnit = friendGO.GetComponent<Unit>();

            if (friendGO != _unit.gameObject &&
                friendUnit?.Exists == true &&
                friendUnit?.Team == _unit.Team &&
                friendUnit?.NormalizedHealth != 1)
            {
                return true;
            }
            return false;
        })
        .ToArray();

        var friendCollider = allFriends
            .OrderBy(f => f.GetComponent<Unit>().CurrentHealth)
            .FirstOrDefault();

        var FriendUnit = friendCollider?.GetComponent<Unit>();

        if (FriendUnit != null)
        {
            _target.Init(FriendUnit, friendCollider);

            _stateMachine.ChangeState(_logic.MoveToUnit);
        }
    }

}

