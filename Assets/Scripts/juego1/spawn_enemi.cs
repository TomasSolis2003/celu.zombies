/*using UnityEngine;

public class spawn_enemi : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}

*/
/*using UnityEngine;

public class spawn_enemi : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 3f;
    public int spawnerHealth = 10;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

    public void TakeDamage(int amount)
    {
        spawnerHealth -= amount;

        if (spawnerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
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
*/
using UnityEngine;

public class spawn_enemi : MonoBehaviour
{
    [Header("Spawner")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;
    public int enemiesPerWave = 3;

    [Header("Vida del Spawner")]
    public int spawnerHealth = 10;

    private bool errorShown = false;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 0f, spawnInterval);
    }

    void SpawnWave()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null)
        {
            if (!errorShown)
            {
                Debug.LogWarning("No se puede spawnear enemigos: faltan spawn points o prefab.");
                errorShown = true;
            }
            return;
        }

        for (int i = 0; i < enemiesPerWave; i++)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        }
    }

    public void TakeDamage(int amount)
    {
        spawnerHealth -= amount;

        if (spawnerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
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
