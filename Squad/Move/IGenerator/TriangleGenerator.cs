using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleGenerator : MonoBehaviour, ISquadPositionGenerator
{
    public Vector3[] GetPosition(int count)
    {
        float step = (360) / count;
        List<Vector3> result = new List<Vector3>();

        for (int i = 0; i < count; i++)
        {
            float newStep = step * i;
            int signX = 1; int signY = 1;
            if (newStep < 90) { signX = +1; signY = +1; }
            else if (newStep < 180) { signX = 0; signY = +1; }
            else if (newStep < 270) { signX = 0; signY = -1; }
            else if (newStep < 360) { signX = +1; signY = -1; }

            float step2Rad = Mathf.Deg2Rad * newStep;
            float step2AbsCos = Mathf.Abs(Mathf.Cos(step2Rad));
            float offsetCenter = -0.5f;

            Vector3 vector = new Vector3(signX * step2AbsCos + offsetCenter, 0, signY * (1 - step2AbsCos));
            result.Add(vector);
        }

        return result.ToArray();
    }
}