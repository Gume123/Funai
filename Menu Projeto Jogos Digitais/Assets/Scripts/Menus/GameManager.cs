using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool jogoAcabou;
    public GameObject gameOverUI;

    void Start()
    {
        jogoAcabou = false;
    }

    void Update()
    {
        if (jogoAcabou)
            return;

        if (StatusDoJogador.Vidas <= 0)
        {
            EndGame();
        }
    }

    public void EndGame() // Altera para público
    {
        jogoAcabou = true;
        gameOverUI.SetActive(true);
    }
}
