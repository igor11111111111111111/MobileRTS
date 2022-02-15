using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkerPanel : DemolishableBuildingPanel
{
    public static WorkerPanel Instance { get; private set; }

    public UnityAction<int> OnValueChanged;

    [SerializeField] private Text _worker;
    [SerializeField] private Text _production;
    [SerializeField] private Button _minus;
    [SerializeField] private Button _plus;

    private IProduceResources _currentBuilding => _building as IProduceResources;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    protected override void Start()
    {
        base.Start();
        _plus.onClick.AddListener(Plus);
        _minus.onClick.AddListener(Minus);
    }

    public override void Init(Building building)
    {
        if (_currentBuilding != null)
        {
            OnValueChanged -= _currentBuilding.RecountWorkers;
        }
        base.Init(building);
        OnValueChanged += _currentBuilding.RecountWorkers;
        OnValueChanged?.Invoke(0);
    }

    private void Plus()
    {
        if (_currentBuilding.CurrentWorkers.Count < _currentBuilding.MaxWorkers)
        {
            OnValueChanged?.Invoke(+1);
        }
    }

    private void Minus()
    {
        if (_currentBuilding.CurrentWorkers.Count > 0)
        {
            OnValueChanged?.Invoke(-1);
        }
    }

    public void DisplayPanel(BuildingProfile profile)
    {
        DisplayDefaultInfo(profile);
    }

    public void DisplayIncome(float worker, float maxWorker, float production)
    {
        _worker.text = worker + "/" + maxWorker;
        _production.text = production.ToString();
    }
}
