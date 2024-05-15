using System.Collections;
using UnityEngine;

public class StatusDoJogador : MonoBehaviour
{
    public static int Dinheiro; //Importante n�o colocar um valor nesse INT pois caso voce reinicie o jogo, queremos que volte o dinheiro inicial e n�o o valor subtra�do ou somado de rodadas anteriores
    public int dinheiroInicial = 400;

    public static int Vidas;
    public int vidasInicial = 200;

    public static int Rounds;

    void Start()
    {
        Dinheiro = dinheiroInicial;
        Vidas = vidasInicial;

        Rounds = 0;
    }
}
