using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEngine.UI;


public class LeitorDeNPC : MonoBehaviour {
    private string contentChar;
    private JsonData charData;
    private string nome, sobrenome, origem, item;
    public int qualNPC;
    public Text hpDisplay;

    // Use this for initialization
    void Start () {
        Invoke("readJson", 3f);
	}

    void readJson() {
        if (qualNPC == 1)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/Procedurais/primeiro.json");
            charData = JsonMapper.ToObject(contentChar);
            hpDisplay = GameObject.Find("quest1").GetComponent<Text>();

        }
        else if (qualNPC == 2)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/Procedurais/segundo.json");
            charData = JsonMapper.ToObject(contentChar);
            hpDisplay = GameObject.Find("quest2").GetComponent<Text>();

        }
        else if (qualNPC == 3)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/Procedurais/terceiro.json");
            charData = JsonMapper.ToObject(contentChar);
            hpDisplay = GameObject.Find("quest3").GetComponent<Text>();

        }
        else {
            contentChar = File.ReadAllText(Application.dataPath + "/Procedurais/quarto.json");
            charData = JsonMapper.ToObject(contentChar);
            hpDisplay = GameObject.Find("quest4").GetComponent<Text>();

        }
        writeStrings();
    }
    void writeStrings() {
        nome = charData["Nome"].ToString();
        sobrenome = charData["Sobrenome"].ToString();
        origem = charData["LugarDeOrigem"].ToString();
        item = charData["Item"].ToString();

        Debug.Log(nome + " " + sobrenome + ", de " + origem + ", quer um(a) " + item);
        hpDisplay.text = nome + " " + sobrenome + ", de " + origem + ", quer um(a) " + item;

    }

}
