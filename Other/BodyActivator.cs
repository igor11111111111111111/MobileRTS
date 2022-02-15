using UnityEngine;

public class BodyActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject _body;

    private void OnEnable()
    {
        _body.SetActive(false);
    }
}
