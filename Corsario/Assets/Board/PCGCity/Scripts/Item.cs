using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string nomeItem;
    public Sprite canvasSprite;
    private GameObject panelItem;


	// Use this for initialization
	void Awake () {
        panelItem = GameObject.Find("PanelItens");
	
	}

    public void pegarItem() {
        panelItem.GetComponent<ItensPanel>().AddImagem(this.canvasSprite);
        Destroy(this.gameObject);
    }

}
