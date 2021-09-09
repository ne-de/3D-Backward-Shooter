using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int m_score = 0;
    private int m_enemiesDown;

    private void Start()
    {
        EnemyDeath.OnEnemyDeath += EnemyDownCount;
    }

    void EnemyDownCount()
    {
        m_enemiesDown++;
    }

    void ScoreCount()
    {
        m_score = m_enemiesDown;
    }

    private void Update()
    {
        ScoreCount();
    }

    void OnGUI()
    {
        if (GameManager.GameOver)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 800, 800), "Game Over\nYour score is: " + ((int)m_score) + "\nTap screen to restart");
            GUI.skin.label.fontSize = 40;
        }
        else if (!GameManager.GameStarted)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 800, 800), "Tap to start");
            GUI.skin.label.fontSize = 40;
        }
        else if (GameManager.GameWon)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 800, 800), "YOU WON!\nYour score is: " + ((int)m_score) + "\nTap screen to restart");
            GUI.skin.label.fontSize = 40;
        }

        GUI.color = Color.green;
        GUI.Label(new Rect(30, 10, 800, 100), "Score: " + ((int)m_score));
        GUI.skin.label.fontSize = 40;
    }
}
