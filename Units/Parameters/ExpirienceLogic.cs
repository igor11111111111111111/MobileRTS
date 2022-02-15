using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ExpirienceLogic : MonoBehaviour
{
    private static int baseXP = 10;
    public static List<int> TresholdValue { get; private set; } 
        = new List<int> { -1, 0, 100, 250, 600, 1000 };

    public static void TryRewardMurderer(Unit murderer, Unit victim)
    {
        if(murderer != null)
        {
            murderer.Expirience += 
                (baseXP + victim.ExpMurdererGet) * 
                (1 + 0.15f * (GetLevel(victim.Expirience) - 1));
        }
    } 
     
    public static int GetLevel(float expirience)
    {
        var maxValue = TresholdValue
            .Where(v => v <= expirience)
            .Max();

        return TresholdValue.IndexOf(maxValue);
    }

    public static void CheckLevelChange(Unit unit)
    {
        var newLevel = GetLevel(unit.Expirience);
        if (unit.Level < newLevel)
        {
            unit.Level = newLevel;
        }
    }

    public static float PositionOnSlider(Unit unit)
    {
        var level = GetLevel(unit.Expirience);
        if (level == TresholdValue.Count() - 1)
        {
            return 0;
        }
        return  (unit.Expirience - TresholdValue[level]) / (TresholdValue[level + 1] - TresholdValue[level]);
    }
}
