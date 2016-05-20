using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using LitJson;

public class GameManager : MonoBehaviour{
    public static GameManager instance = null;

    public int index;
    public bool runnigGame = false;

    public List<Mission> missionsPlayer = new List<Mission>();
    public List<Item> itensPlayer = new List<Item>();
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
        mission = GameObject.Find("PanelMission").GetComponent<MissionPanel>();
        if (missionsPlayer.Count < 3){
            missionsPlayer.Add(newMission);
            mission.AddMission(newMission);

        }else{
            Debug.Log("Sem espaço para mais missoes");
        }
    }

    public void addItem(Item newItem){
        panelItem = GameObject.Find("PanelItens").GetComponent<ItensPanel>();
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
                foreach(Item i in itensPlayer)
                {
                    if (i.nomeItem == m.itemBusca)  itensPlayer.Remove(i);
                }
                missionsPlayer.Remove(m);
                check = true;
            }
            check = false;
        }
    }

    public void GoScene(int _index) {
        index = _index;
        SceneManager.LoadScene("test");

    }


}
