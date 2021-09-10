using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //EVENTS
    public delegate void OnMaxEnemiesSpawnedDelegate(int maxEnemiesToSpawn);
    public static event OnMaxEnemiesSpawnedDelegate OnMaxEnemiesSpawned;

    //PUBLIC
    public Transform[] spawnPoint;
    public float spawnRate;
    public int maxEnemiesToSpawn;

    //PRIVATE
    private float m_timer;
    private float m_enemySpawnCount;

    private Transform RandomizeSpawnPoint()
    {
        int _actualSpawnPointArrayPos = Random.Range(0, spawnPoint.Length);

        return spawnPoint[_actualSpawnPointArrayPos];
    }

    private void Start()
    {
        OnMaxEnemiesSpawned(maxEnemiesToSpawn);        
    }

    void Update()
    {
        m_timer += Time.deltaTime;

        if (GameManager.GameStarted)
        {
            GameObject _enemy = EnemyPooling.SharedInstance.GetPooledObject();
            if (_enemy != null)
            {
                if (m_timer > 1 / spawnRate)
                {
                    _enemy.transform.position = RandomizeSpawnPoint().position;
                    _enemy.transform.rotation = RandomizeSpawnPoint().rotation;
                    _enemy.SetActive(true);

                    m_timer = 0;
                    m_enemySpawnCount++;

                    if (m_enemySpawnCount >= maxEnemiesToSpawn)
                    {
                        this.enabled = false;
                    }
                }
            }
        }
    }
}
