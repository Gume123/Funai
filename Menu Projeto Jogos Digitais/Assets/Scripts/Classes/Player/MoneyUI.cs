using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    void Update() //Atualizar o dinheiro que o jogador tem
    {
        moneyText.text = "R$" + StatusDoJogador.Dinheiro.ToString();
    }
}
