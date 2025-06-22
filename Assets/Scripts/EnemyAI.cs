
/*using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int health = 10;
    public int damage = 1;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }

    
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);

                float distance = Vector3.Distance(transform.position, target.position);

                // Verificar si el jugador está en rango de ataque
                if (distance <= attackRange)
                {
                    attackTimer -= Time.deltaTime;

                    if (attackTimer <= 0f)
                    {
                        PlayerHealth player = target.GetComponent<PlayerHealth>();
                        if (player != null)
                        {
                            player.TakeDamage(damage);
                            attackTimer = attackCooldown;
                        }
                    }
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // ✅ Método que causaba el error por estar ausente
    public void HitBarricade(Barricade barricade)
    {
        if (barricade != null)
        {
            barricade.TakeDamage(damage);
        }
    }
   
}
*/
/*using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    public Transform target;
    public int health = 10;
    public int damage = 1;

    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= attackRange)
            {
                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0f)
                {
                    PlayerHealth player = target.GetComponent<PlayerHealth>();
                    if (player != null)
                    {
                        player.TakeDamage(damage);
                        attackTimer = attackCooldown;
                    }
                }
            }
        }
    }

    // ✅ Implementación de IDamageable
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // ✅ Sigue funcionando para Barricade directamente
    public void HitBarricade(Barricade barricade)
    {
        if (barricade != null)
        {
            barricade.TakeDamage(damage);
        }
    }
}
*/
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable
{
    private Transform target;
    public int health = 10;
    public int damage = 1;

    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    private void Start()
    {
        // Buscar al jugador por su tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("EnemyAI: No se encontró ningún GameObject con tag 'Player'");
        }
    }

    private void Update()
    {
        if (target != null)
        {
            // Movimiento hacia el jugador
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);

            float distance = Vector3.Distance(transform.position, target.position);

            // Ataque si está dentro del rango
            if (distance <= attackRange)
            {
                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0f)
                {
                    PlayerHealth player = target.GetComponent<PlayerHealth>();
                    if (player != null)
                    {
                        player.TakeDamage(damage);
                        attackTimer = attackCooldown;
                    }
                }
            }
        }
    }

    // Implementación de daño
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HitBarricade(Barricade barricade)
    {
        if (barricade != null)
        {
            barricade.TakeDamage(damage);
        }
    }
}
