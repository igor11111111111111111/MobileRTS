using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduceResources : IUseEfficiency
{
    public float ProductionIncome { get; }
    public List<Worker> CurrentWorkers { get; }
    public int MaxWorkers { get; }
    public int ProductPerWorker { get; }

    public void RecountWorkers(int newWorkers);
}
