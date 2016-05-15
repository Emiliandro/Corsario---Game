using UnityEngine;
using System.Collections;

public class ArrowForce : MonoBehaviour {
    private int interval = 1;
    private float nextTime = 0;
    public bool direita;
    // Use this for initialization
    void Update () {
        if (Time.time >= nextTime)
        {
            if (direita) GetComponent<Rigidbody2D>().velocity = new Vector2(2f, -0.5f);
            if (!direita) GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, -0.5f);
            nextTime += interval;
            Invoke("Kill", 1f);
        }

    }
    void Kill() {
        print("destruido");
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
   {
        if (other.tag == "Zumbi")
        {
            Destroy(gameObject);
        }
    }
}
