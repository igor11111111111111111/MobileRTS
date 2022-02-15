
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

public class SelectedUnits : MonoBehaviour
{
    public UnityAction OnSelect;
    [SerializeField] private GameObjectsSO _selectedUnits;
    [SerializeField] private BodySquadPanelActivator _bodyActivator;
    private Camera _camera;

    private void OnEnable()
    {
        _bodyActivator.OnDeselect += Deselect;
    }

    private void OnDisable()
    {
        _bodyActivator.OnDeselect -= Deselect;
    }
     
    private void Start()
    {
        _selectedUnits.List.Clear();
        _camera = Camera.main;
        Vector3 _startPos = Vector3.zero;

        PositionOnGesture.OnSelectDown += (startPos) =>
        {
            Deselect();
            _startPos = startPos;
        };

        PositionOnGesture.OnSelectUp += (endPos) =>
        {
            Select(_startPos, endPos);
            OnSelect?.Invoke();
        };
    }

    private void Select(Vector3 start, Vector3 end)
    {
        SelectingUnits(start, end);
        AuraSelection(true);
    } 

    private void Deselect()
    {
        AuraSelection(false);
        _selectedUnits.List.Clear();
    }

    private void SelectingUnits(Vector3 start, Vector3 end)
    {
        var collidersAll = PhysicsExtension.OverlapScreenBox(start, end, _camera);

        var collidersUnits = collidersAll
        .Where(col =>
        {
            var unit = col.GetComponent<Unit>();
            
            if (unit is Unit && unit.Team == Enums.Team.Player && unit.Exists)
            {
                unit.OnDeath += () => Exclude(unit);
                return true;
            }
            else
                return false;
        })
        .ToList();

        _selectedUnits.List = collidersUnits.ConvertToGO();
    }

    private void Exclude(Unit unit)
    {
        _selectedUnits.List.Remove(unit.gameObject);
        Destroy(unit.Presenter.gameObject);
    }

    private void AuraSelection(bool active)
    {
        foreach (var unit in _selectedUnits.List)
        {
            if (unit != null)
                unit.GetComponent<Unit>().Fixtures.AuraSelection.SetActive(active);
        }
    }
}

