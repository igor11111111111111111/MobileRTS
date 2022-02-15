using UnityEngine;

public class BuildingGhost : MonoBehaviour
{  
    public static BuildingGhost Instance { get; private set; }
    public PlacedEntity CurrentEntity;
    [SerializeField]
    private BuildingsSO _buildings;
    [SerializeField]
    private GameObject _buildingControllerBody;
    private GameObject _ghost;
    [SerializeField]
    private Transform _parent;

    private void OnEnable()
    {
        Instance = this;
    }
    
    private void OnDisable()
    {
        Instance = null;
    }

    private void Start()
    {
        _buildings.List.Clear();
    }

    public void TryCreate(BuildingProfile profile)
    {
        if (CurrentEntity != null) return;

        _buildingControllerBody.SetActive(true);
         
        PhysicsRaycasterExtension.Instance.TurnOffMask("PlacedBuilding");
        
        _ghost = Instantiate(profile.BuildingView, GetSpawnPosition(), Quaternion.identity, _parent);

        CurrentEntity = new PlacedEntity(_ghost.GetComponent<Building>(),
                                         _ghost.GetComponent<CollisionTrigger>(),
                                         _ghost.GetComponent<StateHelper>(),
                                          profile);

        _buildings.List.Add(_ghost);
    }

    private Vector3 GetSpawnPosition()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)) { }
        return new Vector3(hit.point.x, 0, hit.point.z);
    }

    public void Destroy()
    {
        Destroy(_ghost);
        _buildings.List.RemoveAt(_buildings.List.Count - 1);
        CurrentEntity = null;
    }
}
