using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public static class ConvertExtension
{
    //public static List<T1> ConvertFromTo<T0,T1>(this List<T0> l0s) where T0 : Component
    //{
    //    List<T1> l1 = new List<T1>();
    //    foreach (var t0 in l0s)
    //    {
    //        l1.Add(t0.GetComponent<T1>());
    //        Debug.Log(t0.GetComponent<T1>());
    //    }

    //    return l1;
    //}

    public static List<GameObject> ConvertToGO(this List<Collider> colliders)
    {
        List<GameObject> list = new List<GameObject>();
        foreach (var collider in colliders)
        {
            if (collider != null)
                list.Add(collider.gameObject);
        }
        return list;
    }

    public static List<T1> ConvertTo<T1>(this List<GameObject> gameObjects)
    {
        List<T1> list = new List<T1>();
        foreach (var gameObject in gameObjects)
        {
            if(gameObject != null)
                list.Add(gameObject.GetComponent<T1>());
        }
        return list;
    }
}
