using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class StackArrows : MonoBehaviour
{
    [SerializeField]
    private GameObject _arrow;
    private static GameObject _stArrow; 
    private static Stack _stack;

    private void Start()
    {
        _stack = new Stack();
        _stArrow = _arrow;
    }

    public static void Push(GameObject gameObject)
    {
        _stack.Push(gameObject);
    }

    public static GameObject Pop()
    {
        if(_stack.Count == 0)
        {
            var arrow = Instantiate(_stArrow);
            _stack.Push(arrow);
        }
        return (GameObject)_stack.Pop();
    }
}
