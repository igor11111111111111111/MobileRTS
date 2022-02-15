using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateHelper : MonoBehaviour
{
    [SerializeField]
    private GameObject _good;
    [SerializeField]
    private GameObject _bad;

    private void Start()
    {
        StateGood();
    }

    public void StateGood()
    {
        _good.SetActive(true);
        _bad.SetActive(false);
    }

    public void StateBad()
    {
        _good.SetActive(false);
        _bad.SetActive(true);
    }

    public void StateOff()
    {
        _good.SetActive(false);
        _bad.SetActive(false);
    }
}
