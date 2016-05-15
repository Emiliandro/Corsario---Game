using UnityEngine;
using System.Collections;

public class Movement2D : MonoBehaviour {
    public static Movement2D instance;
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
    [SerializeField]
    private GameObject arrow;
	private int count;

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

    void Update(){
        if (Input.GetKey(right) && !attcking)
        {
            attcking = false;
            count = 1;
        }
        else if (Input.GetKey(left) && !attcking)
        {
            attcking = false;
            count = 2;
        }
        else if (Input.GetKey(up) && !attcking)
        {
            attcking = false;
            count = 3;
        }
        else if (Input.GetKey(down) && !attcking)
        {
            attcking = false;
            count = 4;
        }
        else if (Input.GetKey(attck))
        {
            attcking = true;
        }
        else
        {
            count = 0; attcking = false;
        }
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
