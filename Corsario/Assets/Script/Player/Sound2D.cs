using UnityEngine;
using System.Collections;

public class Sound2D : MonoBehaviour {
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode attck = KeyCode.LeftShift;
	[SerializeField] private AudioClip audios;

	void FixedUpdate(){
	}
}
