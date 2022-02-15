using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ResourcePresenter : MonoBehaviour
{
    public Text Value;
    public Text Income; 
    public Image Icon;

    public void StartPresent(ResourceProfile profile)
    {
        PresentIncome(profile);
        PresentValue(profile);
        Icon.sprite = profile.Icon;
    }
     
    public void PresentValue(ResourceProfile profile)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Mathf.RoundToInt(profile.Value));

        if (profile.ShowMaxValue)
        {
            sb.Append("/" + Mathf.RoundToInt(profile.MaxValue));
        }

        if (profile is PeopleProfile)
        {
            sb.Append("(" + (profile as PeopleProfile).Worker?.Count + ")");
        }

        Value.text = sb.ToString();

    }

    public void PresentIncome(ResourceProfile profile)
    {
        if(profile.ShowIncome)
        {
            Income.text = Math.Round(profile.Income, 2).ToString();
        }

        else
        {
            Income.text = null;
        }
    }
}
