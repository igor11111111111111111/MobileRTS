
using UnityEngine;
using UnityEngine.EventSystems;

public class Citadel : Building
{
    public static Citadel Instance { get; private set; }
    [SerializeField]
    private GameObject _lord;
    [SerializeField]
    private Transform _startingLordPoint;

    protected override void OnEnable()
    {
        base.OnEnable();
        Instance = this;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        Instance = null;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        CitadelPanel.Instance.DisplayPanel(Profile);
    }

    public override void ConstructionComplete()
    {
        Instantiate(_lord, _startingLordPoint.position, Quaternion.identity);
    }
}
