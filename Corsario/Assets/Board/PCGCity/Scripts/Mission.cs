using UnityEngine;
using System.Collections;


[System.Serializable]
public class Mission {
    public string agentName;
    public string missionDesc;
    public bool missionStatus;
    public string itemBusca;

    public Mission(string _agentName, string _missionDesc, string _itemName) {
        this.agentName = _agentName;
        this.missionDesc = _missionDesc;
        this.itemBusca = _itemName;
    }
}
