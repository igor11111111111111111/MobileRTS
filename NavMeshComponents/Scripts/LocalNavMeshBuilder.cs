using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[DefaultExecutionOrder(-102)]
public class LocalNavMeshBuilder : MonoBehaviour
{
    public static LocalNavMeshBuilder Instance;
    [SerializeField] private Vector3 _size;
    private NavMeshData _meshData;
    private List<NavMeshBuildSource> _sources;

    private void Awake()
    {
        _meshData = new NavMeshData();
        _sources = new List<NavMeshBuildSource>();
        NavMesh.AddNavMeshData(_meshData);
        UpdateNavMesh();
    }

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void UpdateNavMesh()
    {
        NavMeshSourceTag.Collect(ref _sources);
        var defaultBuildSettings = NavMesh.GetSettingsByID(0);
        var bounds = new Bounds(Quantize(transform.position, 0.1f * _size), _size);

        NavMeshBuilder.UpdateNavMeshData(_meshData, defaultBuildSettings, _sources, bounds);
    }

    private static Vector3 Quantize(Vector3 v, Vector3 quant)
    {
        float x = quant.x * Mathf.Floor(v.x / quant.x);
        float y = quant.y * Mathf.Floor(v.y / quant.y);
        float z = quant.z * Mathf.Floor(v.z / quant.z);
        return new Vector3(x, y, z);
    }

    private void OnDrawGizmosSelected()
    {
        if (_meshData)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_meshData.sourceBounds.center, _meshData.sourceBounds.size);
        }

        Gizmos.color = Color.yellow;
        var bounds = new Bounds(Quantize(transform.position, 0.1f * _size), _size);
        Gizmos.DrawWireCube(bounds.center, bounds.size);

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _size);
    }
}