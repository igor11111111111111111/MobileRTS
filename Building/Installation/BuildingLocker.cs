using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLocker : MonoBehaviour
{
    public static BuildingLocker Instance;
    [SerializeField] private Economics _economics;
    private List<BuildingProfile> _buildings;
    private int _index;

    private void Awake()
    {
        _index = 4; // на 0
    }

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void Init(List<BuildingProfile> buildings)
    {
        _buildings = buildings;
        NextStage();
    }

    public void NextStage()
    {
        if(_index == 0)
        {
            foreach (var building in _buildings)
            {
                building.Button.SetActive(false);
            }
            _buildings[0].Button.SetActive(true);
        }

        else if(_index == 1)
        {
            _buildings[0].Button.SetActive(false);
            _buildings[1].Button.SetActive(true);
        }

        else if (_index == 2)
        {
            _buildings[1].Button.SetActive(false);
            _buildings[2].Button.SetActive(true);
        }

        else if (_index == 3)
        {
            _buildings[2].Button.SetActive(false);
            for (int i = _index; i < _buildings.Count - 1; i++)
            {
                _buildings[i].Button.SetActive(true);
            }

            //_economics.StartCoroutine("IAddIncome");
        }

        _index++;
    }
}
