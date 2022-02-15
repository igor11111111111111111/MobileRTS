using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class ContainerSpriteState
{
    private static Sprite[] _sprites = Resources.LoadAll<Sprite>("Formation");

    public static Sprite GetSprite(Enums.Stand stand)
    {
        var sprite = _sprites.Where(s => s.name == stand.ToString()).First();

        if(sprite == null)
        {
            throw new System.ArgumentOutOfRangeException("Invalid Enums.Stand or sprite in Resources");
        }

        return sprite;
    }
}
