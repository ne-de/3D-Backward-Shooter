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
        if (GameManager.GamePreStart)
        {
            GUI.color = Color.white;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 1000, 1000), "TAP TO START");
            GUI.skin.label.fontSize = 30;
            GUI.skin.label.fontStyle = FontStyle.Bold;
        }

        else if (GameManager.GameOver)
        {
            GUI.color = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 100, 1000, 1000), "GAME OVER\nScore: " + ((int)m_score) + "\nTap to restart");
            GUI.skin.label.fontSize = 30;
        }
        else if (GameManager.GameWon)
        {
            GUI.color = Color.cyan;
            GUI.Label(new Rect(Screen.width / 2 - 160, Screen.height / 2 - 100, 1000, 1000), "YOU WON!\nScore: " + ((int)m_score) + "\nTap to restart");
            GUI.skin.label.fontSize = 30;
        }

        GUI.color = Color.white;
        GUI.Label(new Rect(30, 10, 800, 100), "Score: " + ((int)m_score));
        GUI.skin.label.fontSize = 30;
    }
}
