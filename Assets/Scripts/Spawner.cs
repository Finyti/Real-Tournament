using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public GameObject floor;

    public bool spawn = true;
    
    public List<Wave> waves;
    public int currentWave = 0;

    public bool waveRepeat;

    public UnityEvent onWaveStarted;
    public UnityEvent onWaveEnded;


    [System.Serializable]
    public class Wave
    {
        public float waveTime = 1f;
        public int enemyCount;

        public float xRange = 1;
        public float yRange = 1;
    }

    private void Start()
    {
        Random.seed = 100;
        WaveCall();
    }


    async void WaveCall()
    {
        bool isOutOfList = waves.Count - 1 < currentWave;
        if (isOutOfList && waveRepeat)
        {
            currentWave -= currentWave;
        }
        isOutOfList = waves.Count - 1 < currentWave;
        if (spawn && !isOutOfList)
        {
            await new WaitForSeconds(waves[currentWave].waveTime);
            Spawn();
        }
    }

    public void Spawn()
    {
        onWaveStarted.Invoke();
        for (int i = 0; i < waves[currentWave].enemyCount; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-waves[currentWave].xRange, waves[currentWave].xRange), Random.Range(-waves[currentWave].yRange, waves[currentWave].yRange), 0);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = transform;
            enemy.transform.position += enemyPos;
            enemy.GetComponent<EnemyAI>().target = player;
            enemy.GetComponent<Health>().floor = floor;
        }
        currentWave++;
        onWaveEnded.Invoke();
        WaveCall();
    }
}
