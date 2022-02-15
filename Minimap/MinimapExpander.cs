using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapExpander : MonoBehaviour
{
    [SerializeField]
    private GameObject _expanded;
    [SerializeField]
    private GameObject _collapsed;
    [SerializeField]
    private Camera _minimapCamera;
    private float _startSize;

    private void Start()
    {
        _expanded.SetActive(false);
        _startSize = _minimapCamera.orthographicSize;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _expanded.SetActive(!_expanded.activeInHierarchy);
            _collapsed.SetActive(!_collapsed.activeInHierarchy);

            _minimapCamera.orthographicSize = _expanded.activeInHierarchy ? 100 : _startSize;
        }
    }
}
