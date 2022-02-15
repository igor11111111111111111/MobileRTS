using System;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Factory : Building, IProduceResources
{
    public Efficiency Efficiency => _efficiency;
    protected Efficiency _efficiency;
    public int ProductPerWorker => _productPerWorker;
    private int _productPerWorker = 1;
    public float ProductionIncome => _productionIncome;
    private float _productionIncome;
    public List<Worker> CurrentWorkers => _currentWorkers;
    private List<Worker> _currentWorkers = new List<Worker>();
    public int MaxWorkers => _maxWorkers;

    private int _maxWorkers = 5;
    [SerializeField] private PeopleProfile _people;
    protected Producer _producer;

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        WorkerPanel.Instance.Init(this);
        RecountIncome();
        WorkerPanel.Instance.DisplayPanel(Profile);
    }

    public override void ConstructionComplete()
    {
        RecountWorkers(1);
        _producer.Producers.Add(this);
    }

    protected override void Destroy()
    {
        _producer?.Producers.Remove(this);
        base.Destroy();
    }

    public void RecountWorkers(int workers)
    {
        if (workers == 0)
            return;
        else if (workers > 0)
            Hire(workers);
        else if (workers < 0)
            Fire(workers);

        RecountIncome();
    }

    private void Hire(int newWorkers)
    {
        for (int i = 0; i < newWorkers; i++)
        {
            if (_people.Unemployed > 0)
            {
                var worker = new Worker();
                worker.Dismiss.Action(() => Dismiss(worker));
                worker.Dismiss.Sub();
                _currentWorkers.Add(worker);
            }
        }
    }

    private void Fire(int oldWorkers)
    {
        for (int i = 0; i < Mathf.Abs(oldWorkers); i++)
        {
            Worker worker = _currentWorkers[0];
            if (worker != null)
            {
                worker.Dismiss.Invoke();
                _currentWorkers.Remove(worker);
            }
        }
    }

    private void RecountIncome()
    {
        _productionIncome = (float)Math.Round(_currentWorkers.Count * _productPerWorker * Efficiency.Value, 2);
        WorkerPanel.Instance.DisplayIncome(_currentWorkers.Count, _maxWorkers, _productionIncome);
    }

    private void Dismiss(Worker worker)
    {
        _currentWorkers.Remove(worker);
        RecountIncome();
    }
}
