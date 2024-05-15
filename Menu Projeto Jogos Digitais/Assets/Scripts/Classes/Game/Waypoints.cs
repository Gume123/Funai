using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    // Refer�ncia ao GameManager
    public GameManager gameManager;

    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

    // Fun��o chamada quando um inimigo chega ao �ltimo ponto do caminho
    public void EnemyReachedEnd()
    {
        gameManager.EndGame(); // Chama a fun��o EndGame do GameManager
    }
}
