using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthButton : MonoBehaviour
{
    public HealthBarCanvas HealthBarCanvas;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => 
            {
                HealthBarCanvas.AltPressed = !HealthBarCanvas.AltPressed;

                if (!HealthBarCanvas.AltPressed)
                {
                    HealthBarCanvas.DisableSliders();
                }
            });
    }
}
