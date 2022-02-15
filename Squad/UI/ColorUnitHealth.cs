using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnitHealth : MonoBehaviour
{
    public static Color GetColor(float normalizedHealth)
    {
        Gradient gradient = new Gradient();

        GradientColorKey[] gck = new GradientColorKey[3];
        gck[0].color = new Color(0.16f, 0.94f, 0f);
        gck[0].time = 1.0F;
        gck[1].color = new Color(0.98f, 1f, 0f);
        gck[1].time = 0.0F;
        gck[2].color = new Color(1f, 0.18f, 0f);
        gck[2].time = -1.0F;

        GradientAlphaKey[] gak = new GradientAlphaKey[3];
        for (int i = 0; i < gak.Length; i++)
        {
            gak[i].alpha = 1.0F;
        }

        gradient.SetKeys(gck, gak);

        return gradient.Evaluate(normalizedHealth);
    }
}
