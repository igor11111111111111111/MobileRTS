using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efficiency : MonoBehaviour
{
    private float _maxDistance;
    private float _minDistance;
    private Building _target;
    public float Value => _value;
    private float _value;

    public Efficiency(float minDistance, float maxDistance, Building target)
    {
        _minDistance = minDistance;
        _maxDistance = maxDistance;
        _target = target;
    }
     
    public void Recount(Vector3 curPos)
    {
        float curDistance = Vector3.Distance(curPos, _target.transform.position);
        _value = Mathf.Clamp01(1 - (curDistance - _minDistance) / (_maxDistance - _minDistance));
        EfficiencyPanel.Instance.Refresh((int)(_value * 100), curPos, _target.transform.position);
    }
}
