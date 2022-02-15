using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMouse : MonoBehaviour
{
    public static SwitchMouse Instance;
    public static Enums.Switch CurrentSwitch;
    [SerializeField]
    private GameObject _moving;
    [SerializeField]
    private GameObject _selection;

    private void Start()
    {
        Instance = this;
        CurrentSwitch = Enums.Switch.Selection;
        SwitchImages(false);
    }

    public void Switch()
    {
        if(CurrentSwitch == Enums.Switch.Moving)
        {
            CurrentSwitch = Enums.Switch.Selection;
            SwitchImages(false);
        }
        else
        {
            CurrentSwitch = Enums.Switch.Moving;
            SwitchImages(true);
        }
    }

    private void SwitchImages(bool active)
    {
        _moving.SetActive(active);
        _selection.SetActive(!active);
    }
}
