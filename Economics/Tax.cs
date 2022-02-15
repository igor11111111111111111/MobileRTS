using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tax : MonoBehaviour
{
    [SerializeField] private ResourceProfile _people;

    private CitadelPanel _citadelPanel;
    public float GoldIncome => _goldIncome;
    private float _goldIncome;
    public float MoodIncome => _moodIncome;
    private float _moodIncome;

    public int CurrentValue => _currentValue;
    private int _currentValue;
    public const int MAX = 7;
    private const float _taxPerHuman = 0.5f;

    private void Start()
    {
        _citadelPanel = CitadelPanel.Instance;
        _citadelPanel.InitTax(this);
        _citadelPanel.OnValueChanged += ValueChanged;

        _currentValue = 4;
    }

    private void OnEnable()
    {
        _people.OnValueChanged += Recount;
    }

    private void OnDisable()
    {
        _people.OnValueChanged -= Recount;
    }

    private void ValueChanged(int value)
    {
        _currentValue += value;
        Recount();
    }

    public void Recount()
    {
        _goldIncome = (_people.Value * _taxPerHuman * (_currentValue - 4));
        _moodIncome = -(_currentValue - 4) * 2;

        if (_people.Value == 0)
        {
            _moodIncome = 0;
        }

        if (_currentValue == 4)
        {
            _moodIncome = 1;
        }

        _citadelPanel.DisplayIncome(_goldIncome, _moodIncome);
    }
}
