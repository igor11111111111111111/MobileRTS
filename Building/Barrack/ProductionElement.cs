using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buildings/Product")]
public class ProductionElement : ScriptableObject
{
    public float TimeForConstruct;
    public Sprite Icon;
    public GameObject Unit;
    public Price Price;
}
