using UnityEngine;
using System.Collections;

public class Sound2D : MonoBehaviour {
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode attck = KeyCode.LeftShift;
	[SerializeField] private AudioSource ouvido;
	[SerializeField] private AudioClip[] audios;

	void FixedUpdate(){
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "City"){
            ouvido.clip = audios[0];
            ouvido.Play();
        }
        else if (other.tag == "Wild") {
            ouvido.clip = audios[1];
            ouvido.Play();

        }
        else if (other.tag == "Start") {
            ouvido.clip = audios[2];
            ouvido.Play();

        }
    }
}
