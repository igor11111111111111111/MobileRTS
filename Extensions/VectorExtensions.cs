using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 ToVector2XZ(this Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.z);
    }

    public static float Distance(Unit unit1, Unit unit2)
    {
        return Vector3.Distance(unit1.transform.position, unit2.transform.position);
    }

    public static Vector3 GetFrightRunDestination(Unit stalker, Unit pursued)
    {
        var stalkerPos = stalker.transform.position;
        var pursuedPos = pursued.transform.position;
        var hypotenuse = pursued.FrightRunDistance - Vector3.Distance(stalkerPos, pursuedPos);
        Vector3 destination;

        var stalkerAboutZero = (stalkerPos - pursuedPos);
        if(stalkerAboutZero.z != 0)
        {
            var aspectRatio = Mathf.Abs(stalkerAboutZero.x / stalkerAboutZero.z);
            var z = -Mathf.Sign(stalkerAboutZero.z) * Mathf.Abs(Mathf.Sqrt((hypotenuse * hypotenuse) / (aspectRatio * aspectRatio + 1)));
            var x = -Mathf.Sign(stalkerAboutZero.x) * Mathf.Abs(aspectRatio * z);
            destination = new Vector3(x, 0, z) + pursuedPos;
        }
        else
        {
            var aspectRatio = Mathf.Abs(stalkerAboutZero.z / stalkerAboutZero.x);
            var z = -Mathf.Sign(stalkerAboutZero.z) * Mathf.Abs(Mathf.Sqrt((hypotenuse * hypotenuse) / (aspectRatio * aspectRatio + 1)));
            var x = -Mathf.Sign(stalkerAboutZero.x) * Mathf.Abs(aspectRatio * z);
            destination = new Vector3(z, 0, x) + pursuedPos;
        }

        return destination;
    }
}
