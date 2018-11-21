using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum EstadoSpawn {SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float tiempoEntreOleadas = 5f;
    public float waveCountdown;

    private EstadoSpawn estado = EstadoSpawn.COUNTING;

	// Use this for initialization
	void Start ()
    {
        waveCountdown = tiempoEntreOleadas;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (waveCountdown <= 0)
        {
            if (estado != EstadoSpawn.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
	}

    private IEnumerator SpawnWave(Wave oleada)
    {
        estado = EstadoSpawn.SPAWNING;
        for (int i = 0; i < oleada.count; i++)
        {
            SpawnEnemy(oleada.enemy);
            yield return new WaitForSeconds(1f / oleada.rate);
        }
        estado = EstadoSpawn.WAITING;
        yield break;
    }

    private void SpawnEnemy(Transform enemy)
    {

    }
}
