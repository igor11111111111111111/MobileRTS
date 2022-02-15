using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitPanel : MonoBehaviour
{
    public List<GameObject> Prefabs;
    public GameObject Button;
    [SerializeField]
    private GameObject _body;
    [SerializeField]
    private Transform _parent;

    private void Start()
    {
        foreach (var Prefab in Prefabs)
        {
            var go = Instantiate(Button, _body.transform);
            go.SetActive(true);
            go.GetComponent<SpawnUnitPresenter>().Present(Prefab, _parent);
        }
    }
}
