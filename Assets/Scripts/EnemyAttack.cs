using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public delegate void OnEnemyHitDelegate();
    public static event OnEnemyHitDelegate OnEnemyHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            OnEnemyHit();
    }
}