using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string nomeItem;
    public Sprite canvasSprite;
    private GameObject panelItem;

    public void pegarItem() {
        if(panelItem == null)
            panelItem = GameObject.Find("PanelItens");
        panelItem.GetComponent<ItensPanel>().AddImagem(this.canvasSprite);
        Destroy(this.gameObject);
    }

}
