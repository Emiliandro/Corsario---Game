using UnityEngine;
using System.Collections;

public class EnemyDano2D : MonoBehaviour
{
   [SerializeField] private int hp = 100;
   [SerializeField] private int dano = 50;
   [SerializeField] private int aleatorio;
    void Start() {
        aleatorio = Random.Range(1, 4);
        if (aleatorio == 1) dano = 50;
        else if (aleatorio == 2) dano = 25;
        else dano = 20;
    }
    void FixedUpdate() {
        if (hp < 0) Destroy(transform.parent.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arrow")
        {
            hp -= dano;
        }
        else if (other.tag == "City") {
            Destroy(transform.parent.gameObject);
        }
    }
}
