using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combate2D : MonoBehaviour
{
    public GameObject arrowDireita, arrowEsquerda, dano;
    public Animation2D esquerda;
    private int interval = 1;
    private float nextTime = 0;
    private float pX, pY, pZ;
    public float hp = 100;
    public Text hpDisplay;


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Disparo();
        }
        if (hp <= 0) Application.LoadLevel("GameOver");
        hpDisplay.text = hp +"%";
    }

    void Disparo()
    {
        if (Time.time >= nextTime)
        {
            pX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            pY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
            pZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
            //Instantiate(arrowEsquerda, new Vector3(pX, pY, pZ), Quaternion.identity);
            if (esquerda) Instantiate(arrowEsquerda, new Vector3(pX, pY, pZ), Quaternion.identity);
            if (!esquerda) Instantiate(arrowDireita, new Vector3(pX, pY, pZ), Quaternion.identity);


            nextTime += interval;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zumbi")
        {
            pX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            pY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
            pZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
            Instantiate(dano, new Vector2 (pX, pY),Quaternion.identity);
          
                hp -= 10;
               
        }
    }
    void Start() {
        hpDisplay = GameObject.Find("hpbar").GetComponent<Text>();
    }
}
