using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Resources/Profile")] 
public class ResourceProfile : ScriptableObject
{  
    public UnityAction OnValueChanged;
    public List<Worker> Workers;
    public string Name => _name;
    [SerializeField] private string _name;
    public int MarketPrice => _marketPrice;
    [SerializeField] private int _marketPrice;
    public float Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value == value)
                return;

            _value = Mathf.Clamp(value, 0, _maxValue);

            Presenter.PresentValue(this);
        }
    }
    [SerializeField] protected float _value;
    public float MaxValue
    {
        get
        {
            return _maxValue;
        }
        set
        {
            if (_value == value)
                return;
            _maxValue = value;
            Presenter.PresentValue(this);
        }
    }
    [SerializeField] protected float _maxValue;
    public float Income
    {
        get
        {
            return _income;
        }
        set
        {
            if (_income == value)
                return;
            _income = value;
            Presenter.PresentIncome(this);
        }
    }
    [SerializeField] private float _income;
    public Sprite Icon => _icon;
    [SerializeField] private Sprite _icon;
    [HideInInspector] public ResourcePresenter Presenter;
    public bool ShowMaxValue => _showMaxValue;
    [SerializeField] private bool _showMaxValue;
    public bool ShowIncome => _showIncome;
    [SerializeField] private bool _showIncome;
    public int StartValue => _startValue;
    [SerializeField] private int _startValue;
    public int StartMaxValue => _startMaxValue;
    [SerializeField] private int _startMaxValue;
    [SerializeField] private float _startIncome;

    public virtual void Init()
    {
        Value = _startValue;
        MaxValue = _startMaxValue;
        Income = _startIncome;
        Workers = new List<Worker>();
    }

    public void ChangeIncome()
    {
        Value += Income;
        if (Income != 0)
            OnValueChanged?.Invoke();
    }
}
