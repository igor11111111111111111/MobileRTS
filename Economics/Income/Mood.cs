using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mood : Producer
{
    public static Mood Instance;
    private Tax _tax;
    private Feed _feed;

    protected override void Awake()
    {
        base.Awake();
        _tax = GetComponent<Tax>();
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
        return _tax.MoodIncome + _feed.MoodIncome;
    }
}
