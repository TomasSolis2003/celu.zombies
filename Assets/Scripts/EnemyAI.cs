
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
            GameManager.Instance.SumarPuntos(10); // suma 10 puntos por enemigo
            Destroy(gameObject);
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
