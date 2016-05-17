using UnityEngine;
using System.Collections;

public class ArrowForce : MonoBehaviour {
    private int interval = 1;
    private float nextTime = 0;
    public bool direita;
    private float forca;
    // Use this for initialization

    void Start() {
        forca = Random.Range(4f, 8f);
    }
    void Update () {

            if (direita) GetComponent<Rigidbody2D>().velocity = new Vector2(forca, -0.5f);
            if (!direita) GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * forca, -0.5f);
            nextTime += interval;
            Invoke("Kill", 1f);
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
