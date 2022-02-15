using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Economics : MonoBehaviour
{
    public UnityAction OnCountIncome;
    public UnityAction OnCountWorkers;
    public UnityAction OnCountLimits;
    private List<ResourceProfile> _resources;

    private Population _population;
    private Feed _feed;
    private Tax _tax;

    private const float _time = 1;

    private void Awake()
    {
        _resources = Resources.LoadAll<ResourceProfile>("Resources").ToList();

        _population = GetComponent<Population>();
        _feed = GetComponent<Feed>();
        _tax = GetComponent<Tax>();
    }

    private void Start()
    {
        StartCoroutine(nameof(IRecountIncome));//
        StartCoroutine(nameof(IRecountPeople));//
    }

    public IEnumerator IRecountIncome() // стартует из BuildingLocker
    {
        _population.StartCoroutine("IPopulationСhange");
        _feed.Recount();
        _tax.Recount();

        while (true)
        {
            OnCountIncome?.Invoke();
            CountIncome();

            OnCountLimits?.Invoke(); // только при постройке / сносе домов

            yield return new WaitForSeconds(_time);
        }
    }

    public IEnumerator IRecountPeople() // стартует из BuildingLocker
    {
        while (true)
        {
            OnCountWorkers?.Invoke();
            CountEmployedPeople();

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CountIncome()
    {
        PeopleProfile people = (PeopleProfile)_resources[0];
        people.ValuePerTime += people.Income;
        if (people.ValuePerTime >= 1)
        {
            people.ValuePerTime--;
            people.ChangeIncome(1);
        }
        else if(people.ValuePerTime <= -1)
        {
            people.ValuePerTime++;
            people.ChangeIncome(-1);
        }

        for (int i = 1; i < _resources.Count - 1; i++)
        {
            _resources[i].ChangeIncome();
        }
    }

    private void CountEmployedPeople()
    {
        PeopleProfile people = (PeopleProfile)_resources[0];
        List<Worker> worker = new List<Worker>();
        foreach (var resource in _resources)
        {
            worker.AddRange(resource.Workers);
        }
        people.Worker = worker;
    }
}
