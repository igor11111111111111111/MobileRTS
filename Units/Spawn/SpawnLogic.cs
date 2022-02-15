using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{
    [SerializeField]
    private Transform _collectionPoint;

    void Start()
    {
        GetComponent<BarrackProduction>().OnNormalCompletion += Spawn;
    }

    private void Spawn(BarrackProduction.InProduction inProgress, Enums.Team team)
    {
        //Vector3 position = new Vector3(
        //        _collectionPoint.position.x + Random.Range(-2, 2),
        //        _collectionPoint.position.y,
        //        _collectionPoint.position.z + Random.Range(-2, 2));

        Vector3 position = _collectionPoint.position + new Vector3(Random.Range(-2, 2), 0, Random.Range(-2, 2));

        var unit = inProgress.Element.Unit;
        unit.GetComponent<Unit>().Team = team;

        Instantiate(unit, position, transform.rotation, null);
    }
}
