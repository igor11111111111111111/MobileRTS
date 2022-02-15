using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentInfo : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public void Present(BuildingProfile profile)
    {
        if (profile.Price.Count == 0)
        {
            _text.fontSize += 3;
            _text.text = "free";
        }

        else if (profile.Price.Count > 0)
        {
            foreach (var price in profile.Price)
            {
                _text.text += price.Value + " " + price.Resource.Name + "\n";
            }
        }

        if (profile.Price.Count > 2)
        {
            _text.fontSize -= 3;
        }
    }
}
