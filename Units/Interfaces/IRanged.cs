using UnityEngine;

public interface IRanged : IWarrior
{
    Vector3 PreShotDistance { get; set; }
    Transform SpawnedAmmoTransform { get; set; }
    int StoppingDistanceDeviations { get; set; }
}

