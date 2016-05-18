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

    public void Update(){
        if (Input.GetKeyDown(right)) esquerda = false;
        if (Input.GetKeyDown(left)) esquerda = true;
        if (Input.GetKeyDown(attck)) attcking = true;

        if (attcking) {
            if (!esquerda) animacoes.Play(listaAnimacoes[3], 0, 1f);
            if (esquerda) animacoes.Play(listaAnimacoes[4], 0, 1f);
            if (Input.GetKeyUp(attck)) attcking = false;

        }

        
    }
}
