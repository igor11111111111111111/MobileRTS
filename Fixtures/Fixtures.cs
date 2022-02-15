using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixtures : MonoBehaviour
{
    public AuraSelection AuraSelection => _auraSelection;
    [SerializeField]
    private AuraSelection _auraSelection;
    public Flag Flag => _flag;
    [SerializeField]
    private Flag _flag;
    [SerializeField]
    private MinimapIcon _minimapIcon;

    private Unit _unit;

    private void Start()
    {
        _unit = GetComponentInParent<Unit>();

        _unit.InitFixtures(this);
        _auraSelection.InitUnit(_unit);
        _auraSelection.SetActive(false);

        _minimapIcon.SetStartColor(_unit);

        if (_unit.Team != Enums.Team.Player)
        {
            _flag.SetActive(true);
        }

        _unit.OnDeath += () => gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _unit.OnDeath -= () => gameObject.SetActive(false);
    }
}
