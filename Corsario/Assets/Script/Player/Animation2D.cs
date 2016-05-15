using UnityEngine;
using System.Collections;

public class Animation2D : MonoBehaviour {
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode attck = KeyCode.LeftShift;
	private bool attcking = false;
	public bool esquerda = false;
	private GameObject player;
	private int count;
	[SerializeField] private Animator animacoes;
	[SerializeField] private string listaAnimacoes;
	//listaAnimacoes[0] idle
	//listaAnimacoes[1] anda direita
	//listaAnimacoes[2] anda esquerda
	//listaAnimacoes[3] ataque na direita
	//listaAnimacoes[4] ataque na esquerda

	void Update(){
		if (Input.GetKey(right)){ attcking = false; esquerda = false; count = 1;
			if (Input.GetKey(attck)) { attcking = true; }
		} else if (Input.GetKey(left)) { attcking = false; esquerda = true; count = 2;
			if (Input.GetKey(attck)) { attcking = true; }
		} else count = 0;
		StartCoroutine(startAttcking());
	}
	void FixedUpdate(){
		if (count == 1) { animacoes.Play(listaAnimacoes[1],-1,0f);
		} else if (count == 2) { animacoes.Play(listaAnimacoes[2],-1,0f);
		} else { animacoes.Play(listaAnimacoes[0],-1,0f);
		}
	}
	private IEnumerator startAttcking (){
		switch (attcking){
		case true:
			if (!esquerda) animacoes.Play(listaAnimacoes[3],-1,0f); break;
		case false:
			if (esquerda) animacoes.Play(listaAnimacoes[4],-1,0f); break;
		}
		yield return new WaitForSeconds (10);
	}
}
