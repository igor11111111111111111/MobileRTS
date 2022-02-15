using System.Collections;
using UnityEngine;

public class Food : Producer
{ 
    public static Food Instance; 
    private Feed _feed;

    protected override void Awake()
    {
        base.Awake();
        _feed = GetComponent<Feed>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Instance = this;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Instance = null;
    }

    protected override float AdditiveIncome()
    {
        return _feed.FoodIncome;
    }
}

