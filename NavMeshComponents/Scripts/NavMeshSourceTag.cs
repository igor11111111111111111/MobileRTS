using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

[DefaultExecutionOrder(-200)]
public class NavMeshSourceTag : MonoBehaviour
{
    public static List<MeshFilter> m_Meshes = new List<MeshFilter>();

    void OnEnable()
    {
        if (TryGetComponent(out MeshFilter filter))
            m_Meshes.Add(filter);
    }

    void OnDisable()
    {
        if (TryGetComponent(out MeshFilter filter))
            m_Meshes.Remove(filter);
    }

    public static void Collect(ref List<NavMeshBuildSource> sources)
    {
        sources.Clear();

        for (var i = 0; i < m_Meshes.Count; ++i)
        {
            var mf = m_Meshes[i];
            if (mf == null) continue;

            var m = mf.sharedMesh;
            if (m == null) continue;

            var s = new NavMeshBuildSource();
            s.shape = NavMeshBuildSourceShape.Mesh;
            s.sourceObject = m;
            s.transform = mf.transform.localToWorldMatrix;
            s.area = 0;
            sources.Add(s);
        }
    }
}


