using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedUnitAction : MonoBehaviour
{
    [SerializeField]
    private GameObject _body;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _text;
    [Space]
    [SerializeField]
    private Sprite _damage;
    [SerializeField]
    private Sprite _heal;

    public void SetBody(Unit unit)
    {
        _body.SetActive(true);

        if (unit is IWarrior)
        {
            _image.sprite = _damage;
            _text.text = unit.Damage.ToString();
        }

        else if (unit is IHeal)
        {
            _image.sprite = _heal;
            _text.text = (unit as IHeal).HealPower.ToString();
        }

        else
        {
            _body.SetActive(false);
        }
    }
}
