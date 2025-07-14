using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class JEFELIBRE : MonoBehaviour
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

    private bool navMeshErrorShown = false;

    [Header("Jefe Final (opcional)")]
    public bool esJefe = false;
    public Transform barraVidaVisual;
    public float escalaMaximaBarra = 1f;
    public GameObject enemigoASpawnear;
    public Transform[] puntosDeSpawn;
    public float intervaloSpawn = 5f;
    private float temporizadorSpawn;

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

        if (esJefe)
        {
            temporizadorSpawn = intervaloSpawn;
            ActualizarBarraVida();
        }
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= detectionRadius)
            {
                if (agent.isOnNavMesh)
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
                    ShowNavMeshErrorOnce();
                }
            }
            else
            {
                if (agent.isOnNavMesh)
                {
                    agent.ResetPath();
                }
                else
                {
                    ShowNavMeshErrorOnce();
                }
            }
        }

        if (esJefe)
        {
            temporizadorSpawn -= Time.deltaTime;
            if (temporizadorSpawn <= 0f)
            {
                GenerarEnemigo();
                temporizadorSpawn = intervaloSpawn;
            }
        }
    }

    void ShowNavMeshErrorOnce()
    {
        if (!navMeshErrorShown)
        {
            Debug.LogWarning("No se pudo mover: el agente no está en una NavMesh.");
            navMeshErrorShown = true;
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

        if (esJefe)
        {
            ActualizarBarraVida();
        }

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

    void ActualizarBarraVida()
    {
        if (barraVidaVisual != null)
        {
            float porcentaje = Mathf.Clamp01((float)currentHealth / maxHealth);
            Vector3 nuevaEscala = barraVidaVisual.localScale;
            nuevaEscala.x = porcentaje * escalaMaximaBarra;
            barraVidaVisual.localScale = nuevaEscala;
        }
    }

    void GenerarEnemigo()
    {
        if (enemigoASpawnear == null || puntosDeSpawn.Length == 0)
            return;

        int indice = Random.Range(0, puntosDeSpawn.Length);
        Instantiate(enemigoASpawnear, puntosDeSpawn[indice].position, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
