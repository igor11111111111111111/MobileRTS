using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhysicsExtension
{

    public static Collider[] OverlapScreenBox(Vector3 startPos, Vector3 endPos, Camera camera)
    {
        float depthCameraGround = 100f;
        
        var leftUp = new Vector2(startPos.x, endPos.y);
        var rightDown = new Vector2(endPos.x, startPos.y);
        var center = new Vector2(startPos.x + endPos.x, startPos.y + endPos.y) / 2;

        var leftDownWorld = camera.ScreenToWorldPoint(startPos);
        var leftUpWorld = camera.ScreenToWorldPoint(leftUp);
        var rightDownWorld = camera.ScreenToWorldPoint(rightDown);
        var centerWorld = camera.ScreenToWorldPoint(center);

        var halfScale = new Vector3(
            Vector3.Distance(leftDownWorld, rightDownWorld) / 2,
            Vector3.Distance(leftDownWorld, leftUpWorld) / 2,
            depthCameraGround);

        if (float.IsNaN(halfScale.x))
            halfScale.x = halfScale.y = 0.1f;

        return Physics.OverlapBox(centerWorld, halfScale, Quaternion.Euler(camera.transform.eulerAngles));
    }
}
