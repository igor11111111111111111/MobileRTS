using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlacedEntity
{
    public BuildingProfile Profile => _profile;
    private BuildingProfile _profile;
    private Building _building;
    private CollisionTrigger _trigger;
    private StateHelper _state;

    public PlacedEntity(Building view, CollisionTrigger trigger, StateHelper state, BuildingProfile profile)
    {
        _building = view;
        _trigger = trigger;
        _state = state;
        _profile = profile;
        BuildingEfficiency();
    }

    public void MoveView(Vector3 pos)
    {
        _building.CurrentTransform.position += pos;
        BuildingEfficiency();
    } 

    public void RotateView(Vector3 angle)
    {
        _building.CurrentTransform.rotation *= Quaternion.Euler(angle);
    }

    public Transform GetTransform()
    {
        return _building.CurrentTransform;
    } 

    public bool TryPlace() 
    {
        if (_trigger.IsCollised) return false;

        ApplySettings();

        return true;
    }

    private void BuildingEfficiency()
    {
        if (_building is IUseEfficiency)
            (_building as IUseEfficiency).Efficiency.Recount(_building.CurrentTransform.position);
    }

    private void ApplySettings()
    {
        _building.Profile = _profile;
        TurnOffCollision();
        SettingUpMask();
        Animate();
        SetTeam(Enums.Team.Player);
        BuildingLocker.Instance.NextStage();
        LocalNavMeshBuilder.Instance.UpdateNavMesh();
        BuildingGhost.Instance.CurrentEntity = null;
    }

    private void Animate()
    {
        Animator animator = GetTransform().GetComponent<Animator>();
        animator.enabled = true;
        animator.Play("UnderConstruction");
    }

    private void SetTeam(Enums.Team team)
    {
        GetTransform().GetComponent<Building>().Team = team;
    }

    private void TurnOffCollision()
    {
        GameObject.Destroy(_trigger);
        _state.StateOff();
    }

    private void SettingUpMask()
    {
        _building.SetPlacedBuildingLayerMask();
        PhysicsRaycasterExtension.Instance.SetStartMask();
    }
}
