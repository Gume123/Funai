using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VidasUI : MonoBehaviour
{
    public TextMeshProUGUI vidasText;

    void Update() //Atualizar quantas vidas o jogador tem
    {
        vidasText.text = StatusDoJogador.Vidas.ToString() + " Vidas";
    }
}
