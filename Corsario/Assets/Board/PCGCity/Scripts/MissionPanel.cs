using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionPanel : MonoBehaviour {

    private int limitMission = 0;
    public GameObject refUi;

    public void AddMission(Mission _mission){
        if (limitMission < 3)
        {
            GameObject missionCanvas = Instantiate(refUi);
            missionCanvas.transform.SetParent(this.transform);
            missionCanvas.GetComponent<Text>().text = _mission.missionDesc;
            Debug.Log("Adicionado ao panel");
            limitMission++;
        }
        else
        {
            Debug.Log("Passou dos limites");

        }

    }

}
