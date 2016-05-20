using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Fungus;

public class GameManager : MonoBehaviour{
    public static GameManager instance = null;

    public int index;

    private List<Mission> missionsPlayer = new List<Mission>();
    private List<Item> itensPlayer = new List<Item>();
    private BoardManager boardInstance;
    public BoardManager boardPrefab;

    public MissionPanel mission;
    public ItensPanel panelItem;

    public GameObject canvasLoadScene;

    void Awake(){
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void addMission(Mission newMission){
        if (missionsPlayer.Count < 3){
            missionsPlayer.Add(newMission);
            mission.AddMission(newMission);

        }else{
            Debug.Log("Sem espaço para mais missoes");
        }
    }

    public void addItem(Item newItem){
        if (itensPlayer.Count < 3){
            itensPlayer.Add(newItem);
            panelItem.AddImagem(newItem.canvasSprite);

        }else{
            Debug.Log("Sem espaço para mais itens");
        }
    }


    public void RemoveMission(string missionNpc, bool check) {
        foreach(Mission m in missionsPlayer){
            if(m.agentName == missionNpc && m.missionStatus){
                missionsPlayer.Remove(m);
                check = true;
            }
            check = false;
        }
    }


}
