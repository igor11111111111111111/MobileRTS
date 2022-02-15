using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourcesPanel : MonoBehaviour
{
    [SerializeField]
    public GameObject _resourceTemplate;
    [SerializeField]
    private Transform _parent;
    private List<ResourceProfile> _resources;

    private void Awake()
    {
        _resources = Resources.LoadAll<ResourceProfile>("Resources").ToList();

        foreach (var resource in _resources)
        {
            var go = Instantiate(_resourceTemplate, _parent);
            var presenter = go.GetComponent<ResourcePresenter>();
            presenter.StartPresent(resource);
            resource.Presenter = presenter;
            resource.Init();
        }

        //RefreshIncome();
        //InvokeRepeating("RefreshValue", 0, 1);
    }
}
