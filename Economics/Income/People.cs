using System.Collections.Generic;
using UnityEngine;

public class People : Producer
{
    public static People Instance;
    [HideInInspector] public List<House> LimitProducers;
    private Population _population;

    protected override void Awake()
    {
        base.Awake();
        LimitProducers = new List<House>();
        _population = GetComponent<Population>();
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
        return _population.PeopleIncome;
    }

    protected override void CountLimits()
    {
        base.CountLimits();
        int maxPeople = 0;
        if (LimitProducers.Count != 0)
        {
            foreach (var producer in LimitProducers)
            {
                maxPeople += producer.CurrentPeople;
            }
            _resourceProfile.MaxValue = maxPeople + _resourceProfile.StartMaxValue;
            //Debug.Log(maxPeople + " " + _resourceProfile.StartValue);
        }
    }
}
