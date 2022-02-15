using System.Collections.Generic;
using UnityEngine.Events;

public class DismissAction
{
    // invoke once and auto unsub
    // Example:
    // Action(() => Test1());
    // Action(() => Test2());
    // .....
    // Sub();
    // Invoke();
    // Invoke(); - dont work, becose auto unsub
    // void Test1() {}
    // void Test2() {}
    private UnityAction _subAction;
    private UnityAction _unsubAction;

    public void Action(UnityAction subAction)
    {
        UnityAction unsubAction = () => Unsub();
        _unsubAction += subAction + unsubAction;
    }

    // activate after all Action

    public void Sub()
    {
        _subAction += _unsubAction;
    }

    private void Unsub()
    {
        _subAction -= _unsubAction;
    }

    public void Invoke()
    {
        _subAction?.Invoke();
    }
}
