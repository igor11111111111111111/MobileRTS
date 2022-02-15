using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums 
{
    public enum Team
    {
        Neutral,
        Player,
        AI
    };

    public enum ClassWarrior
    {
        Knight,
        Archer,
        Priest,
        Necromancer,
        Undead,
        Lord
    }

    public enum Stand
    {
        Aggressive,
        Defensive,
        FrightRun,
        Passive
    }

    public enum Switch
    {
        Moving,
        Selection
    }
}
