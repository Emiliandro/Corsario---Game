﻿using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;


public class EscritorDeNPC : MonoBehaviour
{

    NPCs bluePrint;
    JsonData dataJson;
    public string[] nomes, sobres, origens, profiss, nomesf;
    string nome, sobre, origem, profis, crenca, item;
    int n1, s1, o1, p1, c1;
    public int qualNPC;
    string profissao1, profissao2;

    public void Start()
    {
        if (GameManager.instance.runnigGame){
            Debug.Log("Mantem os npcs");
        }else{
            qualNPC = 1;
            Profissao();
            Debug.Log("Criou os Npcs");
        }
        

    }
    void writeJson()
    {

        if (qualNPC == 1)
        {
            dataJson = JsonMapper.ToJson(bluePrint);
            File.WriteAllText(Application.dataPath + "/primeiro.json", dataJson.ToString());
        }
        else if (qualNPC == 2)
        {
            dataJson = JsonMapper.ToJson(bluePrint);
            File.WriteAllText(Application.dataPath + "/segundo.json", dataJson.ToString());
        }
        else if (qualNPC == 3)
        {
            dataJson = JsonMapper.ToJson(bluePrint);
            File.WriteAllText(Application.dataPath + "/terceiro.json", dataJson.ToString());
        }
        else {
            dataJson = JsonMapper.ToJson(bluePrint);
            File.WriteAllText(Application.dataPath + "/quarto.json", dataJson.ToString());

        }

        qualNPC++;
        if (qualNPC == 2) Profissao();
        else if (qualNPC == 3) Profissao();

    }
    void Construtor()
    {
        bluePrint = new NPCs(nome, sobre, origem, profis, crenca, item);
        
        writeJson();
    }
    void Homem()
    {
        //

        if (qualNPC == 2)
        {
            if (profis != profissao1) {} else Profissao();
        } else if (qualNPC == 3)
        {
            if (profis != profissao1) { } else Profissao();
            if (profis != profissao2) { } else Profissao();
        }


        // CRENCA
        if (profis == "Ferreiro")
        {
            crenca = "Artorias, o senhor das brasas";
            item = "Martelo";
        }
        else if (profis == "Bardo")
        {
            crenca = "Jumala, o deus das festividades";
            item = "Violao";
        }
        else if (profis == "Coveiro")
        {
            crenca = "Peklenc, o juiz do submundo";
            item = "Ornatos";
        }
        else if (profis == "Padre")
        {
            crenca = "Peklenc, o juiz do submundo";
            item = "Livro";
        }
        
        else if (profis == "Guarda")
        {
            crenca = "Santo Graal, o deus das batalhas";
            item = "Lanca";
        }
        else if (profis == "Cacador")
        {
            crenca = "Lyeshi, o deus dos bosques";
            item = "Arco";
        }


        n1 = Random.Range(0, nomes.Length);
        nome = nomes[n1];

        Mulher();
    }
    void Mulher()
    {
        // CRENCA
        if (profis == "Curandeira")
        {
            n1 = Random.Range(0, nomesf.Length);
            nome = nomesf[n1];
            crenca = "Babayaga, a deusa das bruxas";
            item = "Totem";
        }
        else if (profis == "Comerciante")
        {
            n1 = Random.Range(0, nomesf.Length);
            nome = nomesf[n1];
            crenca = "Dola, a personificacao da sorte";
            item = "Manuscritos";
        }
        else if (profis == "Ladra")
        {
            n1 = Random.Range(0, nomesf.Length);
            nome = nomesf[n1];
            crenca = "Dola, a personificacao da sorte";
            item = "Picklocks";
        }



        Construtor();
    }
    void Profissao()
    {
        // PROFISSAO
        p1 = Random.Range(0, profiss.Length);
        s1 = Random.Range(0, sobres.Length);
        o1 = Random.Range(0, origens.Length);
        profis = profiss[p1];
        sobre = sobres[s1];
        origem = origens[o1];
        Debug.Log(profis + profissao1 + profissao2);
        if (qualNPC == 1) profissao1 = profis;
        else if (qualNPC == 2) profissao2 = profis;
        Homem();
    }
    
    
    public enum Personalidade {
        Honesto, // Fala normalmente
        Mentiroso, // Fala confusamente
        Tímido, // Fala pouco
        Excluído // Evita falar
    }
    
    public enum Afiliacoes {
        Good, // Quests uteis
        Neutral, // Quests inuteis
        Evil, // Quests suicidas
    }

}

