using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionPanel : MonoBehaviour
{
    public static ProductionPanel Instance;
    public List<GameObject> Bodys;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void DeactivateAllBodys()
    {
        foreach (var body in Bodys)
        {
            body.SetActive(false);
        }        
    }
}
