using System.Collections.Generic;
using UnityEngine;

public class Gold : Producer
{ 
    public static Gold Instance;
    private Tax _tax;

    protected override void Awake()
    {
        base.Awake();
        _tax = GetComponent<Tax>();
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
        return _tax.GoldIncome;
    }
}
