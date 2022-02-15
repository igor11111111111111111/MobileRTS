using UnityEngine;
using UnityEngine.UI;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] protected GameObject _body;

    protected virtual void Start()
    {
        _body.SetActive(false);
    }

    protected void DisplayDefaultInfo(BuildingProfile profile)
    {
        _body.SetActive(true);
        _name.text = profile.Name;
        _icon.sprite = profile.Icon;
    }
}
