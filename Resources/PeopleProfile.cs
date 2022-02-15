using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Resources/PeopleProfile")]
public class PeopleProfile : ResourceProfile
{
    public List<Worker> Worker;
    public int Unemployed => Mathf.Clamp((Value - Worker.Count), 0, Value);
    public new int Value
    {
        get
        {
            return (int)_value;
        }
        set
        {
            if (_value == value) 
                return;

            value = Mathf.Clamp(value, 0, (int)_maxValue);

            if (_value > value)
            {
                Dismiss((int)_value - value);
            }
            else if (_value < value)
            {
                _value = value; // hire
            }

            Presenter.PresentValue(this);
        }
    }

    public float ValuePerTime;

    public override void Init()
    {
        base.Init(); 
        Worker = new List<Worker>();
        ValuePerTime = 0;
    }

    public void ChangeIncome(int income)
    {
        Value += income;
        if (Income != 0)
            OnValueChanged?.Invoke();
    } 

    private void Dismiss(int count)
    {
        if(Unemployed == 0)
        {
            for (int i = 0; i < count; i++)
            {
                Worker[Random.Range(0, Worker.Count - 1)].Dismiss.Invoke();
            }
        }
        _value -= count;

        Presenter.PresentValue(this);
    }
}
