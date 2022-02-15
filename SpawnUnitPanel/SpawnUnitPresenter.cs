using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnitPresenter : MonoBehaviour
{
    public Text text;
    public Button Button;

    public void Present(GameObject inst, Transform parent)
    {
        text.text = inst.name;
        Button.onClick.AddListener(() => 
        {
            Vector3 pos = Vector3.zero;

            var go = Instantiate(inst, pos, Quaternion.identity, parent);
            var unit = go.GetComponent<Unit>();
            unit.Team = SpawnUnitTeam.Instance.Team;
        });
    }


}
