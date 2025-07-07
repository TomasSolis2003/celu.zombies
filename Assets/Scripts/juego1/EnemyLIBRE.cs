
/*using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLIBRE : MonoBehaviour
{
    [Header("Detección")]
    public float detectionRadius = 10f;
    public float attackRadius = 2f;

    [Header("Combate")]
    public int damage = 10; // Cambiado a int para que coincida con el script del jugador
    public float attackCooldown = 2f;
    private float lastAttackTime;

    [Header("Vida")]
    public float maxHealth = 50f;
    private float currentHealth;

    private NavMeshAgent agent;
    private Transform target;
    private PlayerHealth playerHealth;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= detectionRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= attackRadius && Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                agent.ResetPath();
            }
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Coincide con el método del jugador
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
*/
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyLIBRE : MonoBehaviour
{
    [Header("Detección")]
    public float detectionRadius = 10f;
    public float attackRadius = 2f;

    [Header("Combate")]
    public int damage = 5;
    public float attackCooldown = 2f;
    private float lastAttackTime;

    [Header("Vida")]
    public int maxHealth = 10;
    private int currentHealth;

    private NavMeshAgent agent;
    private Transform target;
    private PlayerHealth playerHealth;

    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
            playerHealth = playerObj.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogWarning("No se encontró un objeto con el tag 'Player'.");
        }
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= detectionRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= attackRadius && Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
            else
            {
                agent.ResetPath();
            }
        }
    }

    void Attack()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    public bool TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
            return true;
        }

        return false;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
