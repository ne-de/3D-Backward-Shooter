using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //PUBLIC
    [Range(1, 10)]
    public float enemySpeed = 4;
    public Transform player;

    //PRIVATE
    private float m_actualEnemySpeed;

    private void Awake()
    {
        m_actualEnemySpeed = enemySpeed;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
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
        enemySpeed = m_actualEnemySpeed;
        transform.position = Vector3.MoveTowards(transform.position, player.position, (m_actualEnemySpeed * 2) * Time.deltaTime);
    }
}
