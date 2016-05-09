using UnityEngine;
using System.Collections;

public class NPCsGerador : MonoBehaviour {
    [SerializeField]private string[] nomes, familias, parentesco, hobbies, adjetivos, profissoes, locais, meses, objetos, monstros;
    [SerializeField]private int[] idades, dias, anos;
    [SerializeField]private int count1, count2, count3;
    [SerializeField]private bool getIdadesDiasAnos = false;
    void Start() {
        count1 = nomes.Length;
        count2 = nomes.Length;
        count3 = nomes.Length;
        if (getIdadesDiasAnos) {
            for (int i = 1503; i < 1601; i++)
            {
                //anos.Add(i); Unity nao encontra metodo, procurar alternativa
            }
            for (int i = 1; i < 29; i++)
            {
                //dias.Add(i); Unity nao encontra metodo, procurar alternativa
            }
            for (int i = 15; i < 70; i++)
            {

                //idades.Add(i); Unity nao encontra metodo, procurar alternativa
            }
        }
        
    }
}
