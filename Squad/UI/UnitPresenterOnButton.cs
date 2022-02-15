using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPresenterOnButton : MonoBehaviour
{
    [SerializeField]
    private Image _portrait;
    [SerializeField]
    private Slider _health;
    [SerializeField]
    private Image _fill;
    [SerializeField]
    private Image _stand;
    [SerializeField]
    private Button _button;

    public void Present(Unit unit)
    {
        unit.Presenter = this;
        _portrait.sprite = unit.Portrait;
        _stand.sprite = ContainerSpriteState.GetSprite(unit.Stand);
        _health.value = unit.NormalizedHealth;
        _fill.color = ColorUnitHealth.GetColor(unit.NormalizedHealth);
        _button.onClick.AddListener(() => SelectedUnitPanel.Instance.Init(unit));
    }
}
