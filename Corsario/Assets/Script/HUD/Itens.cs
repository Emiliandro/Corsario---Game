using UnityEngine;
using System.Collections;

public class Itens : MonoBehaviour
{
    [SerializeField] private bool interagir,falar = true;
    [SerializeField] public GameObject player;
    enum TI {
        Item = 0,
        NPC = 1
    };
    [SerializeField] private TI ti;

    private void start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == player.name) {
            interagir = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D exitOther)
    {
        if (exitOther.name == player.name) {
            interagir = false;
            falar = true;
        } 
    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.E) && interagir && falar)
        {
            falar = false;
            switch (ti)
            {
                case TI.Item:
                    //HUD.instance.SetHud(this.name);
                    Movement2D.instance.SetItem(this.name);
                    Destroy(this.gameObject);
                    break;
                case TI.NPC:
                    Movement2D.instance.NPCAdd(this.name);
                    player.SetActive(false);
                    break;

            }
            
        }
    }
}
