using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
    public static HUD instance;
    public int ordem = 0;
    [SerializeField] private GameObject H0,H1, H2, T;
    [SerializeField] private GameObject[] HUDS = new GameObject[3];

	void Start () {
        if (instance == null)
        {
            instance = this;
        }
        H0 = GameObject.Find("HUD0");
        H1 = GameObject.Find("HUD1");
        H2 = GameObject.Find("HUD2");
    }
	
	void Update () {
    }

    public void SetHud(string Type)
    {
        if (ordem == 0)
        {
            HUDS[0] = GameObject.Find(Type + "_h");
            HUDS[0].transform.position = H0.transform.position;
            HUDS[0].GetComponent<SpriteRenderer>().enabled = true;
            ordem += 1;
        }
        else if (ordem == 1)
        {
            HUDS[1] = GameObject.Find(Type + "_h");
            HUDS[1].transform.position = H1.transform.position;
            HUDS[1].GetComponent<SpriteRenderer>().enabled = true;
            ordem += 1;
        }
        else if(ordem == 2)
        {
            HUDS[2] = GameObject.Find(Type + "_h");
            HUDS[2].transform.position = H2.transform.position;
            HUDS[2].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public void UseHud(string obj)
    {
        if (HUDS[0].name == obj)
        {
            T.transform.position = HUDS[1].transform.position;
            HUDS[1].transform.position = HUDS[0].transform.position;
            HUDS[2].transform.position = T.transform.position;
            HUDS[0].GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (HUDS[1].name == obj)
        {
            ordem -= 1;
        }
        else if (HUDS[0].name == obj)
        {
            ordem -=1;
        }
    }
}
