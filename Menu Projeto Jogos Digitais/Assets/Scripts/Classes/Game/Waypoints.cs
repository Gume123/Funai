using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    // Referência ao GameManager
    public GameManager gameManager;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    // Função chamada quando um inimigo chega ao último ponto do caminho
    public void EnemyReachedEnd()
    {
        gameManager.EndGame(); // Chama a função EndGame do GameManager
    }
}
