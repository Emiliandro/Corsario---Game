using UnityEngine;
using System.Collections;

public class TelaDeDano : MonoBehaviour
{

    void thisDestroy()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Start()
    {
        Invoke("thisDestroy", 0.5f);
    }
}
