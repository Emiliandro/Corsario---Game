using UnityEngine;
using System.Collections;

public class Movement2D : MonoBehaviour {
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode attck = KeyCode.LeftShift;
	[SerializeField] private bool attcking = false;
	[SerializeField] private float velright;
	[SerializeField] private float velleft;
	[SerializeField] private float velup;
	[SerializeField] private float veldown;
	[SerializeField] private GameObject player;
	[SerializeField] private Rigidbody2D player_rb;
	private int count;

	void Update(){
		if (Input.GetKey(right)){
			attcking = false;
			count = 1;
			if (Input.GetKey(attck)) {
				attcking = true;
			}
		}
		else if (Input.GetKey(left))
		{
			attcking = false;
			count = 2;
			if (Input.GetKey(attck)) {
				attcking = true;
			}
		} else if (Input.GetKey(up))
		{
			attcking = false;
			count = 3;
			if (Input.GetKey(attck)) {
				attcking = true;
			}
		} else if (Input.GetKey(down))
		{
			attcking = false;
			count = 4;
			if (Input.GetKey(attck)) {
				attcking = true;
			}
		}
		else count = 0;
	}
	void FixedUpdate(){
		if (count == 1) {
			player_rb.velocity = new Vector2(velright, 0f);
		} else if (count == 2) {
			player_rb.velocity = new Vector2(velleft, 0f);
		} else if (count == 3) {
			player_rb.velocity = new Vector2(0f, velup);
		} else if (count == 4) {
			player_rb.velocity = new Vector2(0f, veldown);
		} else {
			player_rb.velocity = Vector2.zero;
		}
	}
}
