using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitPanel : MonoBehaviour
{
    public static SelectedUnitPanel Instance { get; private set; }
    [SerializeField]
    private SelectedUnitBody _selectedUnitBody;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(Unit unit)
    {
        _selectedUnitBody.Init(unit);
    }
}
