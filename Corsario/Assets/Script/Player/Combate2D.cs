using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combate2D : MonoBehaviour
{
    public GameObject arrowDireita, arrowEsquerda, dano;
    public bool  esquerda = false;
    private int interval = 1;
    private float nextTime = 0;
    private float pX, pY, pZ;
    public float hp = 100;
    public Text hpDisplay, arrowDisplay;
    private int maxArrow = 3;

    void Update() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            esquerda = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            esquerda = true;
        }
    }
    void FixedUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.time >= nextTime)
            {
                pX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
                pY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
                pZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
                nextTime += interval;
            }
            Disparo();
        }
        if (hp <= 0) Application.LoadLevel("GameOver");

        if (hp > 0) hpDisplay.text = hp + "%";
        else if (hp <= 0) hpDisplay.text = "00%";
        arrowDisplay.text = maxArrow.ToString() + " Flechas";
        if (maxArrow < 1) {
            maxArrow = 1;
            Invoke("Less", 2f);
        }
        if (maxArrow >= 4)
        {
            maxArrow = 3;
        }
    }

    void Disparo()
    {
        if (maxArrow > 0)
        { 
        if (esquerda) Instantiate(arrowEsquerda, new Vector3(pX, pY, pZ), Quaternion.identity);
        if (!esquerda) Instantiate(arrowDireita, new Vector3(pX, pY, pZ), Quaternion.identity);
            maxArrow--;

            Invoke("Less", 2f);
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
        arrowDisplay = GameObject.Find("flechas").GetComponent<Text>();
    }
    void Less() {
        maxArrow++;
    }
}
