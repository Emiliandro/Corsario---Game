using UnityEngine;
using System.Collections;

public class Combate2D : MonoBehaviour
{
    public GameObject arrowDireita, arrowEsquerda;
    //public Animation2D esquerda;
    private int interval = 1;
    private float nextTime = 0;
    private float pX, pY, pZ;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Disparo();
        }
        }

    void Disparo()
    {
        if (Time.time >= nextTime)
        {
            pX = GameObject.FindGameObjectWithTag("Player").transform.position.x;
            pY = GameObject.FindGameObjectWithTag("Player").transform.position.y;
            pZ = GameObject.FindGameObjectWithTag("Player").transform.position.z;
            Instantiate(arrowEsquerda, new Vector3(pX, pY, pZ), Quaternion.identity);
               //if (esquerda) Instantiate(arrowEsquerda, new Vector3(pX, pY, pZ), Quaternion.identity);
               // if (!esquerda) Instantiate(arrowDireita, new Vector3(pX, pY, pZ), Quaternion.identity);


            nextTime += interval;
        }
    }
}
