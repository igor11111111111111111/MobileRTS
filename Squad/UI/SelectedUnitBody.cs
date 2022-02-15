using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitBody : MonoBehaviour
{
    private Unit _unit;

    [SerializeField]
    private Image _portrait;
    [SerializeField]
    private Text _health;
    [SerializeField]
    private Text _type;
    [SerializeField]
    private Slider _expirience;
    [SerializeField]
    private Text _level;
    [SerializeField]
    private SelectedUnitAction _action;
    [SerializeField]
    private Text _armor;

    public void Init(Unit unit)
    {
        _unit = unit;
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        StartCoroutine(Refresh());
    }

    private void OnDisable()
    {
        StopCoroutine(Refresh());
        gameObject.SetActive(false);
    }

    IEnumerator Refresh()
    {
        while(true)
        {
            if(_unit != null)
            {
                SetPortrait();
                SetHealth();
                SetType();
                SetExpirience();
                _level.text = _unit.Level.ToString();
                _action.SetBody(_unit);
                _armor.text = _unit.Armor.ToString();
            }
            else
            {
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetType()
    {
        var text = _unit.GetType().ToString();
        var length = text.Length;
        if (length < 10)
        {
            _type.fontSize = 14;
        }
        else if (length >= 10 && length <= 14)
        {
            _type.fontSize = 20 - length;
        }
        else
        {
            _type.fontSize = 6;
        }
        _type.text = text;
    }

    private void SetHealth()
    {
        _health.text = Math.Round( _unit.CurrentHealth, 1) + "/" + _unit.MaxHealth;
        _health.color = ColorUnitHealth.GetColor(_unit.NormalizedHealth);
    }

    private void SetPortrait()
    {
        _portrait.sprite = _unit.Portrait;
    }

    private void SetExpirience()
    {
        _expirience.value = ExpirienceLogic.PositionOnSlider(_unit);
    }
}
