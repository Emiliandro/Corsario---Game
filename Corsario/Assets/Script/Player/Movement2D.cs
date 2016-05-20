using Fungus;
using System.Collections;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public static Movement2D instance;
    private KeyCode right = KeyCode.RightArrow;
    private KeyCode left = KeyCode.LeftArrow;
    private KeyCode up = KeyCode.UpArrow;
    private KeyCode down = KeyCode.DownArrow;
    private KeyCode attck = KeyCode.Z;
    [SerializeField]
    private bool attcking = false;
    [SerializeField]
    private float velright;
    [SerializeField]
    private float velleft;
    [SerializeField]
    private float velup;
    [SerializeField]
    private float veldown;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody2D player_rb;
    [SerializeField]
    private GameObject arrowD, arrowE;
    [SerializeField]
    private Flowchart FC;
    [SerializeField]
    private Animator animacoes;
    [SerializeField]
    private string[] listaAnimacoes;
    private int count, npc = 1;
    private bool esquerda = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        count = 0;
        StartCoroutine(Correction());
        StartCoroutine(getRB());

    }

    IEnumerator Correction()
    {
        velleft = velleft * -1;
        veldown = velup * -1;
        yield return new WaitForSeconds(0);
        print("valores corrigidos");
    }

    IEnumerator getRB()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_rb = player.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(3);
        print("player is connected");
    }

    void Update()
    {

        Physics2D.IgnoreCollision(arrowE.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(arrowD.GetComponent<Collider2D>(), GetComponent<Collider2D>());


        if (Input.GetKeyDown(attck)) attcking = true;
        if (Input.GetKeyUp(attck)) attcking = false;

        if (Input.GetKey(right) && attcking == false)
        {
            attcking = false;
            count = 1;
            if (Input.GetKey(up)) count = 7;
            if (Input.GetKey(down)) count = 8;
            if (Input.GetKeyDown(right))
            {
                animacoes.Play(listaAnimacoes[1], 0, 1f);
            }


        }
        else if (Input.GetKey(left) && attcking == false)
        {
            count = 2;

            if (Input.GetKey(up)) count = 5;
            else if (Input.GetKey(down)) count = 6;
            if (Input.GetKeyDown(left))
            {
                animacoes.Play(listaAnimacoes[2], 0, 1f);
            }
            attcking = false;

        }
        else if (Input.GetKey(up) && attcking == false)
        {
            attcking = false;
            count = 3;
            if (Input.GetKeyDown(up))
            {
                if (esquerda == true) animacoes.Play(listaAnimacoes[2], 0, 1f);
                else animacoes.Play(listaAnimacoes[1], 0, 1f);
            }

        }
        else if (Input.GetKey(down) && attcking == false)
        {
            attcking = false;
            count = 4;
            if (Input.GetKeyDown(down))
            {
                if (esquerda == true) animacoes.Play(listaAnimacoes[2], 0, 1f);
                else animacoes.Play(listaAnimacoes[1], 0, 1f);
            }

        }
        else if (Input.GetKey(attck))
        {
            count = 9;
            attcking = true;
            if (attcking)
            {
                if (Input.GetKeyDown(attck))
                {
                    if (!esquerda) animacoes.Play(listaAnimacoes[4], 0, 1f);
                    if (esquerda) animacoes.Play(listaAnimacoes[5], 0, 1f);
                }
            }
            if (Input.GetKeyUp(attck)) attcking = false;
        }
        else
        {
            count = 0; attcking = false;
            if (esquerda == true) animacoes.Play(listaAnimacoes[3], 0, 1f);
            else animacoes.Play(listaAnimacoes[0], 0, 1f);

        }



    }
    void FixedUpdate()
    {

        if (Input.GetKeyDown(attck))
        {
            player_rb.velocity = new Vector2(0.0000000000000001f, 0.0000000000000001f);
            Debug.Log(player_rb.velocity);
        }
        else if (Input.GetKeyUp(attck)) player_rb.velocity = new Vector2(0f, 0f);
        Debug.Log(count);

        if (count == 1)
        {
            player_rb.velocity = new Vector2(velright, 0f);
            esquerda = false;
        }
        else if (count == 2)
        {
            player_rb.velocity = new Vector2(velleft, 0f);
            esquerda = true;

        }
        else if (count == 3)
        {
            player_rb.velocity = new Vector2(0f, velup);

        }
        else if (count == 4)
        {
            player_rb.velocity = new Vector2(0f, veldown);
        }
        else if (count == 5)
        {
            player_rb.velocity = new Vector2(velleft, velup);
            esquerda = true;

        }
        else if (count == 6)
        {
            player_rb.velocity = new Vector2(velleft, veldown);
            esquerda = true;

        }
        else if (count == 7)
        {
            player_rb.velocity = new Vector2(velright, velup);
            esquerda = false;

        }
        else if (count == 8)
        {
            player_rb.velocity = new Vector2(velright, veldown);
            esquerda = false;

        }
        else if (count == 9)
        {
            player_rb.velocity = new Vector2(0.00000000000000000001f, 0.00000000000000000001f);
        }
        else {
            player_rb.velocity = Vector2.zero;

        }
    }
    public void SetItem(string nome)
    {
        FC.SetBooleanVariable(nome, true);
    }
    public void NPCAdd(string nome)
    {
        FC.SetIntegerVariable(nome, FC.GetIntegerVariable(nome) + 1);
        FC.SendFungusMessage(nome + " Adicionado");
    }
    public void Addnome(string nome)
    {
        if (npc == 1)
        {
            FC.SetStringVariable("N1", nome);
            npc++;
        }
        else if (npc == 2)
        {
            FC.SetStringVariable("N2", nome);
            npc++;
        }
        else if (npc == 3)
        {
            FC.SetStringVariable("N3", nome);
            npc++;
        }
    }
}
