
using UnityEngine;
using System.Linq;

public class SquadPanel : MonoBehaviour
{
    [SerializeField] private GameObject _unitTemplate;
    [SerializeField] private RectTransform _squadGridLayout;
    [SerializeField] private GameObjectsSO _unitsSO;
    [SerializeField] private GameObject _body;
    [SerializeField] private SelectedUnits _selectedUnits;
    private GridLayout _gridLayout;

    private void Awake()
    {
        _gridLayout = new GridLayout();
        InvokeRepeating(nameof(CheckList), 0, 1);
    }

    private void OnEnable()
    {
        _selectedUnits.OnSelect += Activate;
    }

    private void OnDisable()
    {
        _selectedUnits.OnSelect -= Activate;
    }

    private void CheckList()
    {
        if (_unitsSO.List.Count == 0)
        {
            _body.SetActive(false);
        }
    }

    private void Activate()
    {
        _body.SetActive(true);
        _squadGridLayout.sizeDelta = _gridLayout.GetSize(_unitsSO.List.Count());
        _squadGridLayout.ClearChild();

        var units = _unitsSO.List.ConvertTo<Unit>();
        foreach (var unit in units)
        {
            if (unit != null && unit.Exists)
            {
                var go = Instantiate(_unitTemplate, _squadGridLayout);
                go.GetComponent<UnitPresenterOnButton>().Present(unit);
            }
        }
    }

    private class GridLayout
    {
        private const float _startOffset = -3.6f;
        private const float _heightShearRow = 56.8f;
        private const float _countColumn = 7f;

        public Vector2 GetSize(float selectedUnits)
        {
            var countRow = Mathf.Ceil(selectedUnits / _countColumn);
            var height = _startOffset + _heightShearRow * countRow;
            return new Vector2(0, height);
        }
    }
}
