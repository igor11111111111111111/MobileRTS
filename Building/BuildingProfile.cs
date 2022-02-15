using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Buildings/Profile")]
public class BuildingProfile : ScriptableObject
{
    public GameObject BuildingView;
    public string Name; 
    public Sprite Icon;
    public int Health;
    public List<Price> Price;
    [HideInInspector]
    public GameObject Button;
    public String Info;
}


