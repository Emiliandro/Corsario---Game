using UnityEngine;
using System.Collections;
using Fungus;

public class SaidaTrigger : MonoBehaviour {

    public string thisFlow;
    public Flowchart flow;
    public int count = 0;

    void Start(){
        flow = GetComponent<Flowchart>();
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && count == 0){
            if(thisFlow == "SaidaEsquerda")
                flow.SendFungusMessage("GoSceneEsquerda");
            if(thisFlow == "SaidaDireita")
                flow.SendFungusMessage("GoSceneDireita");
            count++;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player")
            count = 0;
    }

    public void SceneGo(int index){
        GameManager.instance.GoScene(index);
    }

}
