using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    Worker worker;

    private void Awake()
    {
        worker = new Worker();
        //worker.Dismiss2.Action(() => test1(worker));
        //worker.Dismiss2.Action(() => test2(worker));
        //worker.Dismiss2.Action(() => test3(worker));
        //worker.Dismiss2.Action(() => test4(worker));
        //worker.Dismiss2.Action(() => test3(worker));
        //worker.Dismiss2.Action(() => test2(worker));
        //worker.Dismiss2.Action(() => test1(worker));
        //worker.Dismiss2.Sub();
        //worker.Dismiss2.Invoke();
        //worker.Dismiss2.Invoke();
    }

    private void test1(Worker worker)
    {
        Debug.Log("test1");
    }

    private void test2(Worker worker)
    {
        Debug.Log("test2");
    }

    private void test3(Worker worker)
    {
        Debug.Log("test3");
    }

    private void test4(Worker worker)
    {
        Debug.Log("test4");
    }
}