using UnityEngine;
using System.Collections;

public class NPCs
{
    public string Nome, Sobrenome, LugarDeOrigem, Profissao, Crenca, Item;
    public NPCs(string nome, string sobrenome,
        string lugarDeOrigem, string profissao,
        string crenca, string item)
    {
        this.Nome = nome;
        this.Sobrenome = sobrenome;
        this.LugarDeOrigem = lugarDeOrigem;
        this.Profissao = profissao;
        this.Crenca = crenca;
        this.Item = item;
    }
}