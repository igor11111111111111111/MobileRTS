using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
  
public class Building : MonoBehaviour, IPointerClickHandler
{
    public UnityAction OnDestroy;
    [HideInInspector]
    public BuildingProfile Profile;
    public float Health => _health;
    protected float _health;
    public Enums.Team Team { get; set; }

    [HideInInspector]
    public Transform CurrentTransform => transform;

    protected virtual void OnEnable()
    {
        OnDestroy += Destroy;
    }

    protected virtual void OnDisable()
    {
        OnDestroy -= Destroy;
    }

    public void SetPlacedBuildingLayerMask()
    {
        CurrentTransform.gameObject.layer = LayerMask.NameToLayer("PlacedBuilding");
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        ProductionPanel.Instance.DeactivateAllBodys();
    }

    public virtual void ConstructionComplete() // animation event
    {
    }

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }
}
