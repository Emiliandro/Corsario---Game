using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItensPanel : MonoBehaviour {

    private int limitItem = 0;
    public GameObject refUi;

    void Start()
    {
        if (GameManager.instance.itensPlayer.Count != 0)
        {
            foreach (Item i in GameManager.instance.itensPlayer)
            {
                AddImagem(i.canvasSprite);
            }
        }
        
    }

    public void AddImagem(Sprite _item) {
        if (limitItem < 3) { 
            GameObject itemCanvas = Instantiate(refUi);
            itemCanvas.transform.SetParent(this.transform);
            itemCanvas.GetComponent<Image>().sprite = _item;
            Debug.Log("Adicionado ao panel");
            limitItem++;
            }else{
            Debug.Log("Passou dos limites");

        }
        
    }

}
