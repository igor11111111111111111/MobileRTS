using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationPanel : MonoBehaviour
{
    [SerializeField]
    private GameObjectsSO _selectedUnits;

    public void SetStand(int stand)
    {
        var units = _selectedUnits.List.ConvertTo<Unit>();
        foreach (var unit in units)
        {
            if (unit != null)
                unit.Stand = (Enums.Stand)stand;
        }
    }
}
