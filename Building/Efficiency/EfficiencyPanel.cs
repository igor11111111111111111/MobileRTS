
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyPanel : MonoBehaviour
{
    public static EfficiencyPanel Instance;
    [SerializeField] private Text _text;
    [SerializeField] private Transform _percents;
    [SerializeField] private GameObject _body;
    [SerializeField] private LineRenderer _line;
    private Vector3 _percentsOffset = new Vector3(0, 10, 0);
    private Vector3 _lineOffset = new Vector3(0, 2, 0);

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void Awake()
    {
        BodyActive(false);
    }

    public void BodyActive(bool active)
    {
        _body.SetActive(active);
    }

    public void Refresh(int value, Vector3 curPos, Vector3 targetPos)
    {
        if (!_body.activeInHierarchy) 
            BodyActive(true);

        _percents.transform.position = curPos + _percentsOffset;
        _text.text = value + "%";

        _line.SetPosition(0, curPos + _lineOffset);
        _line.SetPosition(1, targetPos + _lineOffset);
    }
}
