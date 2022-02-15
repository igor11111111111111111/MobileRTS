using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void SetStartColor(Unit unit)
    {
        if(unit.Team == Enums.Team.AI)
        {
            _sprite.color = new Color(0.71f, 0f, 0f);
        }

        else if (unit.Team == Enums.Team.Player)
        {
            _sprite.color = new Color(0f, 0.6f, 0.09f);
        }

        else if (unit.Team == Enums.Team.Neutral)
        {
            _sprite.color = new Color(0.1f, 0.1f, 0.1f);
        }

    }
}
