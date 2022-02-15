using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
    [SerializeField] private ResourceProfile _people;
    [SerializeField] private ResourceProfile _food;
    private GranaryPanel _granaryPanel; 
    public float FoodIncome => _foodIncome;
    private float _foodIncome;
    public float MoodIncome => _moodIncome;
    private float _moodIncome;

    public int CurrentValue => _currentValue;
    private int _currentValue;
    public const int MAX = 5;
    private const float _foodPerHuman = 0.5f;
    private bool _isUnderImmunity = false;
    private float _immunityTime = 2f;

    private void Start()
    {
        _granaryPanel = GranaryPanel.Instance;
        _granaryPanel.InitFeed(this);
        _granaryPanel.OnValueChanged += PanelValueChanged;

        _currentValue = 3;
    }

    private void OnEnable()
    {
        _people.OnValueChanged += Recount;
    }

    private void OnDisable()
    {
        _people.OnValueChanged -= Recount;
    }

    private void PanelValueChanged(int value)
    {
        _currentValue += value;
        StartCoroutine(nameof(UnderImmunity));
        Recount();
    }

    private IEnumerator UnderImmunity()
    {
        _isUnderImmunity = true;

        yield return new WaitForSeconds(_immunityTime);

        _isUnderImmunity = false;
    }

    public void Recount()
    {
        if(_food.Value == 0 && !_isUnderImmunity)
        {
            _currentValue = 1;
        }
        _foodIncome = -(_people.Value * _foodPerHuman * (_currentValue * 0.5f - 0.5f));
        _moodIncome = (_currentValue - 1) * 4f - 8;

        if(_people.Value == 0 && _food.Value == 0 && _currentValue == 1)
        {
            _moodIncome = 0;
        }

        _granaryPanel.DisplayIncome(_foodIncome, _moodIncome);
    }
}
