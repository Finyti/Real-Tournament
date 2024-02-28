using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public GameObject floor;
    public int countPerWave;
    public float waveTime;
    public float waveTimeReset;

    public float xRange = 1;
    public float yRange = 1;

    public bool spawn = true;


    void Update()
    {
        if (spawn)
        {
            waveTime -= Time.deltaTime;
            if (waveTime <= 0)
            {
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < countPerWave; i++)
        {
            Vector3 enemyPos = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.position += enemyPos;
            enemy.GetComponent<EnemyAI>().target = player;
            enemy.GetComponent<Health>().floor = floor;
        }
        waveTime = waveTimeReset;
    }
}
