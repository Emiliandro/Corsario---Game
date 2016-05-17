using UnityEngine;
using System.Collections;

public class Animation2D : MonoBehaviour {
	private KeyCode right = KeyCode.RightArrow;
	private KeyCode left = KeyCode.LeftArrow;
	private KeyCode up = KeyCode.UpArrow;
	private KeyCode down = KeyCode.DownArrow;
	private KeyCode attck = KeyCode.Z;
	private bool attcking = false;
	public bool esquerda = false;
    private bool playIdle = true;
	//private GameObject player;
	private int count;
	[SerializeField] private Animator animacoes;
	[SerializeField] private string[] listaAnimacoes;
    //listaAnimacoes[0] idle
    //listaAnimacoes[1] anda direita
    //listaAnimacoes[2] anda esquerda
    //listaAnimacoes[3] ataque na direita
    //listaAnimacoes[4] ataque na esquerda
    //listaAnimacoes[5] idle esquerda

    public void Update(){
        if (Input.GetKeyDown(right)) esquerda = false;
        if (Input.GetKeyDown(left)) esquerda = true;
        if (Input.GetKeyDown(attck)) attcking = true;

        if (esquerda)
        {
            if (Input.GetKeyDown(left) || Input.GetKeyDown(up) || Input.GetKeyDown(down))
            {
                playIdle = false;
                animacoes.Play(listaAnimacoes[2], 0, 1f);
            }
            if (Input.GetKeyUp(left) && Input.GetKeyUp(up) && Input.GetKeyUp(down))
            {
                playIdle = true;
            }
            if (playIdle) animacoes.Play(listaAnimacoes[5], 0, 1f);

        }
        if (!esquerda) 
        {
            if (Input.GetKeyDown(right) || Input.GetKeyDown(up) || Input.GetKeyDown(down))
            {
                playIdle = false;
                animacoes.Play(listaAnimacoes[1], 0, 1f);
            }
            if (Input.GetKeyUp(right) && Input.GetKeyUp(up) && Input.GetKeyUp(down))
            {
                playIdle = true;
            }
            if (playIdle) animacoes.Play(listaAnimacoes[0], 0, 1f);
        }
        if (attcking) {
            if (!esquerda) animacoes.Play(listaAnimacoes[3], 0, 1f);
            if (esquerda) animacoes.Play(listaAnimacoes[4], 0, 1f);
            if (Input.GetKeyUp(attck)) attcking = false;

        }

        
    }
}
