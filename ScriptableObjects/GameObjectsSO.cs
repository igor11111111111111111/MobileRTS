using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ListGameObjects")]
public class GameObjectsSO : ScriptableObject
{
    [SerializeField]
    public List<GameObject> List = null;
}
