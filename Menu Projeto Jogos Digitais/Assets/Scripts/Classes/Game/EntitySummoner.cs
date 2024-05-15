using UnityEngine;
using System.Collections;
using TMPro;

public class EntitySummoner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveNumber = 0;

        void Update()
    {
        if (countdown <= 0f) //O tempo para nascer a wave, toda vez que o tempo chegar a 0, a próxima onda nasce, nascendo cada vez mais rápido
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave() // Para as waves ficarem cada vez maiores e também o inimigo não nascer um dentro do outro, por isso o IEnumerator em vez do Void
    {
        waveNumber++;
        StatusDoJogador.Rounds++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
