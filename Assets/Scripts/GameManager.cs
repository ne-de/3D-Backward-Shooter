using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //PUBLIC
    public static bool GameOver = false;
    public static bool GamePreStart = false;
    public static bool GameStarted = false;
    public static bool GameWon = false;

    //PRIVATE
    private int m_enemyDeathCount;
    private int m_totalEnemieSpawned;
    private bool m_winningLineCrossed;

    private void Start()
    {
        EnemyAttack.OnEnemyHit += OnGameOver;
        EnemySpawner.OnMaxEnemiesSpawned += EnemySpawnCounter;
        EnemyDeath.OnEnemyDeath += EnemyDeathCounter;
        GoalTileBehavior.OnWinningLineCrossed += GoalLineCrossed;

        GamePreStart = true;
    }

    void EnemyDeathCounter()
    {
        m_enemyDeathCount++;
    }

    void EnemySpawnCounter(int spawnerSize)
    {
        m_totalEnemieSpawned = spawnerSize;
    }

    void GoalLineCrossed()
    {
        m_winningLineCrossed = true;
    }

    void OnGamePreStart()
    {
        GameStarted = false;
        GameOver = false;
        GameWon = false;
        Time.timeScale = 0;
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            OnGameStarted();
        }
    }

    void WinCondition()
    {
        if (m_enemyDeathCount == m_totalEnemieSpawned || m_winningLineCrossed)
        {
            GameStarted = false;
            GameWon = true;
            Time.timeScale = 0;
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                GameWon = false;
                //Restart current scene
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                GamePreStart = true;
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
        GameOver = false;
        GamePreStart = false;
        Time.timeScale = 1;
        GameStarted = true;
    }

    private void Update()
    {
        if (GamePreStart)
        {
            OnGamePreStart();
        }

        if (GameOver)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                //Restart current scene
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                GameOver = false;
            }
        }

        WinCondition();
    }

    private void OnDisable()
    {
        EnemyAttack.OnEnemyHit -= OnGameOver;
        EnemySpawner.OnMaxEnemiesSpawned -= EnemySpawnCounter;
        EnemyDeath.OnEnemyDeath -= EnemyDeathCounter;
    }
}
