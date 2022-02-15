using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Granary : Building
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        GranaryPanel.Instance.DisplayPanel(Profile);
    }

    public override void ConstructionComplete()
    {

    }
}
