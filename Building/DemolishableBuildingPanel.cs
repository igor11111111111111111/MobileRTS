using UnityEngine;
using UnityEngine.UI;

public class DemolishableBuildingPanel : BuildingPanel
{
    [SerializeField] private Button _destroyButton;
    protected Building _building;

    protected override void Start()
    {
        base.Start();
        _destroyButton.onClick.AddListener(() => _body.SetActive(false));
    }
     
    public virtual void Init(Building building)
    {
        _destroyButton.onClick.RemoveListener(DestroyButtonHandler);
        _building = building;
        _destroyButton.onClick.AddListener(DestroyButtonHandler);
    }

    private void DestroyButtonHandler()
    {
        _building.OnDestroy?.Invoke();
    }
}
