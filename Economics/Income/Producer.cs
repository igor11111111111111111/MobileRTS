using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Producer : MonoBehaviour 
{
    public List<IProduceResources> Producers;
    [SerializeField] protected ResourceProfile _resourceProfile;
    protected Economics _economics;
    private float _income;
     
    protected virtual void OnEnable()
    {
        _economics.OnCountIncome += CountIncome;
        _economics.OnCountWorkers += CountWorkers;
        _economics.OnCountLimits += CountLimits;
    }

    protected virtual void OnDisable()
    {
        _economics.OnCountIncome -= CountIncome;
        _economics.OnCountWorkers -= CountWorkers;
        _economics.OnCountLimits -= CountLimits;
    }

    protected virtual void Awake()
    {
        Producers = new List<IProduceResources>();
        _economics = GetComponent<Economics>();
    }

    private void CountIncome()
    {
        _income = 0;
        if (Producers.Count != 0)
        {
            foreach (var producer in Producers)
            {
                _income += producer.ProductionIncome;
            }
        } 
        _resourceProfile.Income = _income + AdditiveIncome();
    }

    protected abstract float AdditiveIncome();

    private void CountWorkers()
    {
        List<Worker> workers = new List<Worker>();
        if (Producers.Count != 0)
        {
            foreach (var producer in Producers)
            {
                workers.AddRange(producer.CurrentWorkers);
            }
        }
        _resourceProfile.Workers = workers;
    }

    protected virtual void CountLimits()
    {

    }
}

