using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class House : Building, IUseEfficiency
{
    public Efficiency Efficiency => _efficiency;
    private Efficiency _efficiency;
    private int _defaultPeople = 8;
    public int CurrentPeople => _currentPeople;
    private int _currentPeople;

    private void Awake()
    {
        _efficiency = new Efficiency(10, 25, FindObjectOfType<Citadel>());
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
    }

    public override void ConstructionComplete()
    {
        RecountPeople();
        People.Instance.LimitProducers.Add(this);
    }

    private void OnDestroy()
    {
        People.Instance?.LimitProducers.Remove(this);
    }

    public void RecountPeople()
    {
        _currentPeople = Mathf.RoundToInt(_defaultPeople * Efficiency.Value);
    }
}
