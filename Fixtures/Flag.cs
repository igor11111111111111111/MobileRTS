using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField]
    private GameObject _body;

    public void SetActive(bool active)
    {
        _body.SetActive(active);
    }
}
