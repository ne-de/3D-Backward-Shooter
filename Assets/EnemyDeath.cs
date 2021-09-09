using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public delegate void OnEnemyDeathDelegate();
    public static event OnEnemyDeathDelegate OnEnemyDeath;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            OnEnemyDeath();
            gameObject.SetActive(false);
        }
    }
}
