using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnitTeam : MonoBehaviour
{
    public Text Text;
    public Enums.Team Team;
    public static SpawnUnitTeam Instance;

    private void Start()
    {
        Instance = this;
        Team = Enums.Team.Player;
        GetComponent<Button>().onClick.AddListener(ChangeTeam);
    }

    private void ChangeTeam()
    {
        if(Team == Enums.Team.Player)
        {
            Team = Enums.Team.AI;
        }
        else
        {
            Team = Enums.Team.Player;
        }

        Text.text = "Team: " + Team;
    }
}
