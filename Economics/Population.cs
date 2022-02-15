using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Population : MonoBehaviour
{
    [SerializeField] private ResourceProfile _mood;
    public float PeopleIncome => _peopleIncome;
    private float _peopleIncome;

    private const float _defaultTime = 4f;
    private const float _moodCoef = 0.06f;
    private const float _moodThreshold = 50;
     
    public IEnumerator IPopulationСhange() // стартует из Economics
    {
        while (true)
        {
            float time = Mathf.Abs(Mathf.Abs(_mood.Value - _moodThreshold) * _moodCoef - _defaultTime);
            time = (float)Math.Round(time, 1);
            int sign = (int)Mathf.Sign(_mood.Value - _moodThreshold);

            _peopleIncome = sign / time;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
