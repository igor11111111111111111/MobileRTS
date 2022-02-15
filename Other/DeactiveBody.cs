using UnityEngine;

public class DeactiveBody : MonoBehaviour
{
    [SerializeField]
    private GameObject _body;

    private void OnEnable()
    {
        _body.SetActive(false);
    }
}
