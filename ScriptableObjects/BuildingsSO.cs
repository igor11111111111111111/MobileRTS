using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ListBuildings")]
public class BuildingsSO : ScriptableObject
{
    [SerializeField] private List<GameObject> _list = null;

    public List<GameObject> List { get => _list; }
}
