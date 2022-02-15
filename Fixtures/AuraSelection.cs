using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class AuraSelection : MonoBehaviour
{
    private Unit _unit;
    [SerializeField]
    private GameObject _mesh;

    public void InitUnit(Unit unit)
    {
        _unit = unit;
    }

    public void SetActive(bool active)
    {
        _mesh.SetActive(active);
    }
}
