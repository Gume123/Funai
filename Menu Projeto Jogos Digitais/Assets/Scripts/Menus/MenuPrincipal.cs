using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    public void PlayGame()
    {
        // Carrega a cena do jogo
        SceneManager.LoadScene("Jogo");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
