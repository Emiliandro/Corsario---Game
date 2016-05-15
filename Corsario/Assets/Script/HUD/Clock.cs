using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
    public GameObject ceu;
    public GameObject relogio;
    public float horas;
    private int interval = 1;
    private float nextTime = 0;

	void Start () {
	
	}

    void FixedUpdate()
    {
        if (Time.time >= nextTime)
        {
            Invoke("Horas", 1f * Time.deltaTime);

            nextTime += interval;

        }
    }
    void Horas() {
        if (horas != -360) horas-=1;
        if (horas <= -360) horas = 0;
        relogio.transform.Rotate(0f, 0f, horas * Time.deltaTime);

    }
}
