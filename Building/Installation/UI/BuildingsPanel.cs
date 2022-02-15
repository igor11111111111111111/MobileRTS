using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsPanel : MonoBehaviour
{
    public GameObject BuildingButtonTemplate;
    [SerializeField]
    private Transform _buttonParent;
    private List<BuildingProfile> _buildings;

	void Start ()
    {
        _buildings = Resources.LoadAll<BuildingProfile>("Buildings").ToList();

        foreach (var building in _buildings)
        {
            var buildingButton = Instantiate(BuildingButtonTemplate, _buttonParent);
            building.Button = buildingButton;
            buildingButton.GetComponent<BuildingPresenterOnButton>().Present(building);
        }

        BuildingLocker.Instance.Init(_buildings); 
    }
}
