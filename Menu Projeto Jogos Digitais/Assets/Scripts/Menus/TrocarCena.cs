using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoPorEntrada : MonoBehaviour
{
    public string nomeDaCenaDoMenuInicial;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(nomeDaCenaDoMenuInicial);
        }
    }
}
