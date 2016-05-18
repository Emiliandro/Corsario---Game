using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

    public int index;

    private List<Mission> missionsPlayer = new List<Mission>();
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
    }

    public bool addMission(Mission newMission) {
        if (missionsPlayer.Count < 3) {
            missionsPlayer.Add(newMission);
            mission.AddMission(newMission);
            return true;
        }
        return false;
        
    }

    public void startGScene(int index) {
        canvasLoadScene.SetActive(true);
        Debug.Log("Começou");
        boardInstance.GenerateScene(index);
    }

    public IEnumerator startPScene() {
        yield return new WaitForSeconds(0.5f);
        canvasLoadScene.SetActive(false);
        Debug.Log("Carregou a cena: " + boardInstance.sceneName());
    }

    // Use this for initialization
    void Start () {
        boardInstance = Instantiate(boardPrefab) as BoardManager;
        startGScene(index);
	}
 

}
