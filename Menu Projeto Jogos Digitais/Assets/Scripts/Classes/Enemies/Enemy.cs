using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int valor = 25;
    public int vida = 100;

    private Transform target;
    private int wavePointIndex = 0;

    void Start() //O Objetivo do Inimigo � ir de Waypoint em Waypoint at� o fim da fase
    {
        target = Waypoints.points[0];
    }

    void Update() //Aqui marcamos a vida dele, a dire��o onde ele tem que ir e que ele tem que ir at� o pr�ximo Waypoint
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

    void GetNextWaypoint() //Ir para pr�ximo Waypoint
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
