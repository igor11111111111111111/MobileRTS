using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEditor;

public class ConsoleCleaner : MonoBehaviour
{
    //public static void ClearLog() // не может найти editor
    //{
    //    var assembly = Assembly.GetAssembly(typeof(Editor));
    //    var type = assembly.GetType("UnityEditor.LogEntries");
    //    var method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //    Debug.Log("---Cleaned---");
    //}
}
