using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //PUBLIC
    [Range(1, 7)]
    public float enemySpeed = 4;
    public float enemySprintingSpeed = 8;
    public Transform player;

    //PRIVATE
    private float m_baseEnemySpeed;
    private float m_enemyReferenceSpeed;
    private float m_actualEnemySpeed;

    private void Awake()
    {
        m_baseEnemySpeed = enemySpeed;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        PlatformWall.OnWallContact += EnemySpeedBooster;
        PlatformWall.OnWallClear += EnemySpeedRestorer;
        EnemyDeath.OnEnemyDeath += EnemySpeedRestorer;

        m_enemyReferenceSpeed = m_baseEnemySpeed;
    }

    private void OnEnable()
    {
        m_actualEnemySpeed = enemySpeed;
    }

    private void Update()
    {
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        if (GameManager.GameStarted && !GameManager.GameOver)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, m_actualEnemySpeed * Time.deltaTime);
        }
    }

    void EnemySpeedBooster()
    {
        m_actualEnemySpeed = enemySprintingSpeed;
    }

    void EnemySpeedRestorer()
    {
        m_actualEnemySpeed = m_baseEnemySpeed;
    }

    private void OnDisable()
    {
        PlatformWall.OnWallContact -= EnemySpeedBooster;
        PlatformWall.OnWallClear -= EnemySpeedRestorer;
        EnemyDeath.OnEnemyDeath -= EnemySpeedRestorer;
    }
}
