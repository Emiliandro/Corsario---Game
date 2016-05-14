using UnityEngine;
using System.Collections;

public class Itens : MonoBehaviour
{
    [SerializeField]
    private bool interagir;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player") interagir = true;
    }

    private void OnTriggerExit2D(Collider2D exitOther)
    {
        if (exitOther.tag == "Player") interagir = false;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.E) && interagir)
        {
            if (this.name == "Branco")
            {
                HUD.instance.UseHud("Violão_h");
            }
            if (this.name == "Branco1")
            {
                HUD.instance.UseHud("trans_h");
            }
            else
            {
                HUD.instance.SetHud(this.name);
                Destroy(this.gameObject);
            }
        }
    }
}
