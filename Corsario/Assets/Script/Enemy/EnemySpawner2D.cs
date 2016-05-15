using UnityEngine;
using System.Collections;

public class EnemySpawner2D : MonoBehaviour {
    private int aleatorio;
    [SerializeField]
    private int minimo = 1;
    [SerializeField]
    private int maximo = 5;
    public GameObject zumbi;

	// Use this for initialization
	void Start () {
        aleatorio = Random.Range(minimo, maximo);
        for (int i = 0; i < aleatorio; i++) {
            Instantiate(zumbi);
        }
	}

}
