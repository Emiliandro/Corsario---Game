using UnityEngine;
using System.Collections;

public class NPCMission : MonoBehaviour {

    NPCs npcCurrent;
    public Mission mission;

	// Use this for initialization
	void CreateMission () {
        mission = new Mission(npcCurrent.Nome,
            "Arrume o item " + npcCurrent.Item,
            npcCurrent.Item);	
	}

    public void GetMission(){
        GameManager.instance.addMission(this.mission);
    }


}
