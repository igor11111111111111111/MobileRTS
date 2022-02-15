using UnityEngine;

public interface IResurrect : ISupport
{
    int DelayResurrect { get; set; }
    GameObject ResurrectedUndead { get; set; }
}

