using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PurchaseBuilding
{
    private List<ResourceProfile> _resources;
    private List<Price> _prices;
    private List<bool> _availableResources = new List<bool>();

    public void Init()
    {
        _resources = Resources.LoadAll<ResourceProfile>("Resources").ToList();
    }

    public bool TryPurchase()
    {
        _prices = BuildingGhost.Instance.CurrentEntity.Profile.Price;
        CheckingAvailability();

        if (!_availableResources.Contains(false))
        {
            foreach (var price in _prices)
            {
                var index = _resources.IndexOf(price.Resource);
                _resources[index].Value -= price.Value;
            }

            return true;
        }

        else
        {
            // звук | картинка нужно больше данного ресурса
            return false;
        }
    }

    private void CheckingAvailability()
    {
        _availableResources.Clear();

        foreach (var price in _prices)
        {
            if (_resources.Contains(price.Resource))
            {
                var index = _resources.IndexOf(price.Resource);

                if (_resources[index].Value >= price.Value)
                {
                    _availableResources.Add(true);
                }

                else
                {
                    _availableResources.Add(false);
                }
            }
        }
    }
}
