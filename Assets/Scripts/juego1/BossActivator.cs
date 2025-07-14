/*using System.Collections.Generic;
using UnityEngine;

public class ZombieBossSpawner : MonoBehaviour
{
    [Header("General")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Movimiento")]
    public float moveSpeed = 2f;
    public Transform player;

    [Header("Daño cuerpo a cuerpo")]
    public int damage = 1;

    [Header("Spawn")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int enemiesPerPhase = 3;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Fases de invocación
    private bool phase75 = false;
    private bool phase50 = false;
    private bool phase25 = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        HandleMovement();
        CheckPhases();
    }

    void HandleMovement()
    {
        if (player == null) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    void CheckPhases()
    {
        float healthPercent = currentHealth / maxHealth;

        if (!phase75 && healthPercent <= 0.75f)
        {
            phase75 = true;
            SpawnEnemies();
        }
        if (!phase50 && healthPercent <= 0.5f)
        {
            phase50 = true;
            SpawnEnemies();
        }
        if (!phase25 && healthPercent <= 0.25f)
        {
            phase25 = true;
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerPhase; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            spawnedEnemies.Add(enemy);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Destruir enemigos invocados
        foreach (GameObject enemy in spawnedEnemies)
        {
            if (enemy != null)
                Destroy(enemy);
        }

        Destroy(gameObject); // destruir jefe
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Suponiendo que el jugador tiene un método TakeDamage(int)
            collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}*/
using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Vida del Jefe")]
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Generación de enemigos")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;

    [Header("UI Visual")]
    public Transform lifeBar; // Cubo de barra de vida
    public float lifeBarMaxScaleX = 1f;

    private float spawnTimer;

    void Start()
    {
        currentHealth = maxHealth;
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnEnemies();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemies()
    {
        if (enemyPrefab == null || spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        UpdateLifeBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateLifeBar()
    {
        if (lifeBar != null)
        {
            float healthRatio = Mathf.Clamp01((float)currentHealth / maxHealth);
            Vector3 newScale = lifeBar.localScale;
            newScale.x = healthRatio * lifeBarMaxScaleX;
            lifeBar.localScale = newScale;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if (projectile != null)
            {
                TakeDamage(projectile.damage);
                Destroy(other.gameObject);
            }
        }
    }
}
