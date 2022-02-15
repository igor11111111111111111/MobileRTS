using UnityEngine;
using UnityEngine.Events;

public class BodySquadPanelActivator : MonoBehaviour
{
    public UnityAction OnDeselect;
    [SerializeField]
    private GameObject _body;
    
    private void OnEnable()
    {
        _body.SetActive(false);
    }

    private void OnDisable()
    {
        OnDeselect?.Invoke();
    }
}
