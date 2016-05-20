using UnityEngine;
using System.Collections;

public class MainMenuS : MonoBehaviour {

	[SerializeField]private GameObject[] items;
	[SerializeField]private string[] cenas;
	private int count;
	void Awake ()
	{

		count = 0;
	}

	void Update () { 
		if (count == 0)
		{
			items[0].transform.localScale = new Vector3(3f, 3f, 3f);
			items[1].transform.localScale = new Vector3(1.4f, 1.4f, 1f);
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				count = 1; 
			}
			if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
			{
				Application.LoadLevel(cenas[0]);
			}
		}
		else {
			items[1].transform.localScale = new Vector3(3f, 3f, 3f);
			items[0].transform.localScale = new Vector3(1.4f, 1.4f, 1f);

			if (Input.GetKeyUp(KeyCode.LeftArrow)){
				count = 0;
			}
			if (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space))
			{
				Application.LoadLevel(cenas[1]);
			}
		}


	}

}
