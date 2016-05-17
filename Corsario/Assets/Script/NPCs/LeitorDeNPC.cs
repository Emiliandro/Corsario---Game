using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;
using UnityEngine.UI;


public class LeitorDeNPC : MonoBehaviour {
    private string contentChar;
    private JsonData charData;
    private string nome, sobrenome, origem, item, profissao, crenca;
    public int qualNPC;
    int background;
    // Use this for initialization
    void Start () {
        Invoke("readJson", 3f);
	}

    void readJson() {
        if (qualNPC == 1)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/primeiro.json");
            charData = JsonMapper.ToObject(contentChar);

        }
        else if (qualNPC == 2)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/segundo.json");
            charData = JsonMapper.ToObject(contentChar);

        }
        else if (qualNPC == 3)
        {
            contentChar = File.ReadAllText(Application.dataPath + "/terceiro.json");
            charData = JsonMapper.ToObject(contentChar);

        }
        else {
            contentChar = File.ReadAllText(Application.dataPath + "/quarto.json");
            charData = JsonMapper.ToObject(contentChar);

        }
        writeStrings();
    }
    void writeStrings() {
        nome = charData["Nome"].ToString();
        profissao = charData["Profissao"].ToString();
        sobrenome = charData["Sobrenome"].ToString();
        origem = charData["LugarDeOrigem"].ToString();
        item = charData["Item"].ToString();
        crenca = charData["Crenca"].ToString();

        Debug.Log(nome + " " + sobrenome + ", de " + origem + ", quer um(a) " + item);
        writeBackground();
    }
    void writeBackground() {
        background = Random.Range(0, 2);
        if (background == 1)
        {
            Debug.Log(nome + " " + sobrenome + " vem de uma familia de " + origem + ". com a queda virou um devoto de " + crenca + ", mas secretamente vai a cultos de Jumala.");
        }
        else {
            Debug.Log(nome + " " + sobrenome + " vem de uma familia de fazendeiros de " + origem + ", mas com a queda decidiu ser " + profissao + ".");

        }
    }

}
