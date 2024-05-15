using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int valor = 25;
    public int vida = 100;

    private Transform target;
    private int wavePointIndex = 0;

    void Start() //O Objetivo do Inimigo é ir de Waypoint em Waypoint até o fim da fase
    {
        target = Waypoints.points[0];
    }

    void Update() //Aqui marcamos a vida dele, a direção onde ele tem que ir e que ele tem que ir até o próximo Waypoint
    {
        if (vida <= 0)
        {
            StatusDoJogador.Dinheiro += valor;
            Destroy(gameObject);
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() //Ir para próximo Waypoint
    {
        if (wavePointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        target = Waypoints.points[wavePointIndex];
    }

    void EndPath() //O que acontece se chegar ao fim do caminho
    {
        StatusDoJogador.Vidas--; // Reduz a vida do jogador
        Destroy(gameObject);
    }

    public void TomarDano(int dmg) //O Inimigo toma dano
    {
        vida -= dmg;
    }
}
