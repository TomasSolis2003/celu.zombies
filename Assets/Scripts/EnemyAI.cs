
/*using UnityEngine;

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
*/
/*using UnityEngine;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour, IDamageable
{
    private Transform target;
    public int health = 10;
    public int maxHealth = 10; // nuevo
    public int damage = 1;

    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    public Slider healthBar; // Referencia al Slider

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("EnemyAI: No se encontró ningún GameObject con tag 'Player'");
        }

        // Inicializar la barra de vida
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }

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

        // Opcional: hacer que la barra mire a la cámara
        if (healthBar != null)
        {
            healthBar.transform.parent.rotation = Camera.main.transform.rotation;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (healthBar != null)
        {
            healthBar.value = health;
        }

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
*/
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour, IDamageable
{
    private Transform target;
    public int health = 10;
    public int maxHealth = 10;
    public int damage = 1;

    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;

    private Slider healthBar;

    void Start()
    {
        // Buscar el jugador
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }

        // Buscar el Slider automáticamente dentro del prefab
        healthBar = GetComponentInChildren<Slider>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }

    void Update()
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

        // Hacer que la barra siempre mire a la cámara
        if (healthBar != null)
        {
            healthBar.transform.parent.rotation = Camera.main.transform.rotation;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (healthBar != null)
        {
            healthBar.value = health;
        }

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
