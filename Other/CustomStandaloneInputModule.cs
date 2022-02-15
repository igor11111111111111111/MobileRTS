using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
public class CustomStandaloneInputModule : StandaloneInputModule
{
    public Vector3 GetMousePositionOnGameObject()
    {
        var mainPointerData = GetLastPointerEventData(kMouseLeftId);
        if (IsPointerOverGameObject(kMouseLeftId) && GetCurrentFocusedGameObject().layer == LayerMask.NameToLayer("UI"))
            return Vector3.zero;

        return mainPointerData.pointerCurrentRaycast.worldPosition;
    }
}
