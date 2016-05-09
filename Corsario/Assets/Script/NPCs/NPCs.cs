using UnityEngine;
using System.Collections;

[SerializeField]
public class NPCs {
    public enum Genero {
        MASCULINO = 0,
        FEMININO = 1
    }
    public string Nome, Familia, Profissao, EventoHistorico, NomeDoPai, NomeDaMae, EventoHistoricoDoPai, EventoHistoricoDaMae;
    public int Idade, IdadeDoPai, IdadeDaMae;
    public enum Saude {
        SAUDAVEL = 0,
        DOENTE = 1,
        ADOECENDO = 2
    }
    public enum Estado {
        SOLTEIRO = 0,
        CASADO = 1,
        VIUVO = 2
    }
    public enum EstadoDoPai {
        VIVO = 0,
        MORTO = 1,
        DESAPARECIDO = 2
    }
    public enum EstadoDaMae {
        VIVO = 0,
        MORTO = 1,
        DESAPARECIDO = 2
    }
    public Genero _Genero;
    public Saude _Saude;
    public Estado _Estado;
    public EstadoDoPai _EstadoDoPai;
    public EstadoDaMae _EstadoDaMae;

    public NPCs( string nome, string familia, string profissao, string eventohistorico, string nomedopai, string nomedamae, string eventohistoricodopai, string eventohistoricodamae, int idade,
        int idadedopai, int idadedamae, Genero genero, Saude saude, Estado estado, EstadoDoPai estadodopai, EstadoDaMae estadodamae){
        this.Nome = nome;
        this.Familia = familia;
        this.Profissao = profissao;
        this.EventoHistorico = eventohistorico;
        this.NomeDoPai = nomedopai;
        this.NomeDaMae = nomedamae;
        this.EventoHistoricoDoPai = eventohistoricodopai;
        this.EventoHistoricoDaMae = eventohistoricodamae;
        this.Idade = idade;
        this.IdadeDoPai = idadedopai;
        this.IdadeDaMae = idadedamae;
        this._Genero = genero;
        this._Saude = saude;
        this._Estado = estado;
        this._EstadoDoPai = estadodopai;
        this._EstadoDaMae = estadodamae;
    }
}
