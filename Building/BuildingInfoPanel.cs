using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoPanel : MonoBehaviour
{
    public static BuildingInfoPanel Instance;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _name;
    [SerializeField] private Text _info;
    [SerializeField] private Text _price;
    [SerializeField] private GameObject _body;

    private void OnEnable()
    {
        Instance = this;
    }

    private void OnDisable()
    {
        Instance = null;
    }

    public void Present(BuildingProfile profile)
    {
        _body.SetActive(true);
        _icon.sprite = profile.Icon;
        _name.text = profile.Name;
        _info.text = profile.Info;
        SetPrice(profile.Price);
    }

    private void SetPrice(List<Price> prices)
    {
        if (prices.Count == 0)
        {
            _price.text = "Free";
        }

        else if (prices.Count > 0)
        {
            string text = null;
            text = "Price: ";

            foreach (var price in prices)
            {
                text += price.Value + " " + price.Resource.Name + ", ";
            }

            _price.text = text.Remove(text.Length - 2);
        }
    }
}
