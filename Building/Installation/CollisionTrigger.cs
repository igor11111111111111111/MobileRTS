using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CollisionTrigger : MonoBehaviour
{
    public bool IsCollised => _isCollised;
    private bool _isCollised;

    public UnityEvent OnCollised = new UnityEvent();
    public UnityEvent OnFree = new UnityEvent();

    public void OnCollisionStay(Collision collision)
    {
        if (!_isCollised)
        {
            OnCollised.Invoke();
        }
        _isCollised = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        OnFree.Invoke();

        _isCollised = false;
    }
}
