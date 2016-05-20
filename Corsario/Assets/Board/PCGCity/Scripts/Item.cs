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
        GameManager.instance.itensPlayer.Add(this);
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            pegarItem();
        }
    }

}
