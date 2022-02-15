
using UnityEngine;
using UnityEngine.EventSystems;

public class Barrack : Building
{
    private BarrackProduction _barrackProduction;

    private void Start()
    {
        _barrackProduction = GetComponent<BarrackProduction>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        BarrackPanel.Instance.Init(this);
        BarrackPanel.Instance.DisplayProduction(_barrackProduction, Profile);
        StartCoroutine(_barrackProduction.CustomUpdate());
    }
}
