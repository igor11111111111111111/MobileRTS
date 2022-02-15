using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuildingPresenterOnButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ 
    public Text BuildingName;
    public Image Icon;
    public Button Button;
    private BuildingProfile _profile;
    private int _time;

    public void OnPointerDown(PointerEventData eventData)
    {
        _time = 0;
        StartCoroutine(nameof(Timer));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopAllCoroutines();
    }

    IEnumerator Timer()
    {
        while (_time < 2)
        {
            _time++;
            if (_time == 2)
            {
                BuildingInfoPanel.Instance.Present(_profile);
            }

            yield return new WaitForSeconds(1);
        }
    }

    public void Present(BuildingProfile profile)
    {
        _profile = profile;
        Icon.sprite = profile.Icon;
        BuildingName.text = profile.Name;

        Button.onClick.AddListener(() =>
        {
            BuildingGhost.Instance.TryCreate(profile);
        });
    }
}
