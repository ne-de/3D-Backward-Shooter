﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameOver = false;
    public static bool GameStarted = false;
    public static bool GameWon = false;

    private int m_enemyDeathCount;
    private int m_totalEnemieSpawned;

    private void Start()
    {
        EnemyAttack.OnEnemyHit += OnGameOver;
        EnemySpawner.OnMaxEnemiesSpawned += EnemySpawnCounter;
        EnemyDeath.OnEnemyDeath += EnemyDeathCounter;
    }

    private void EnemyDeathCounter()
    {
        m_enemyDeathCount++;
    }

    void EnemySpawnCounter(int spawnerSize)
    {
        m_totalEnemieSpawned = spawnerSize;
    }

    private void WinCondition()
    {
        if (m_enemyDeathCount == m_totalEnemieSpawned/* || winningLineCrossed*/)
        {
            GameWon = true;
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                GameWon = false;
                //Restart current scene
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }

    void OnGameOver()
    {
        GameOver = true;
        GameStarted = false;
        Time.timeScale = 0;
    }

    void OnGameStarted()
    {
        Time.timeScale = 1;
        GameStarted = true;
    }

    private void Update()
    {
        if (GameOver || !GameStarted)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                if (GameOver)
                {
                    //Restart current scene
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    GameOver = false;
                }
                else
                {
                    //Start the game
                    OnGameStarted();
                }
            }
        }

        WinCondition();
    }

    private void OnDisable()
    {
        EnemyAttack.OnEnemyHit -= OnGameOver;
    }
}