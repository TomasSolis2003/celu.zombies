using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Zona de Spawn")]
    public Vector3 spawnCenter;          // Centro de la zona
    public Vector3 spawnSize = new Vector3(20f, 0f, 20f); // Tamaño (X-Z)

    [Header("Prefabs de enemigos")]
    public GameObject[] enemyPrefabs;    // Lista de prefabs para spawnear

    [Header("Configuración")]
    public int spawnAmount = 10;         // Cuántos enemigos spawnean
    public float spawnInterval = 5f;     // Tiempo entre spawns
    public bool repeatSpawning = true;   // ¿Spawnea infinitamente?

    private float timer;

    void Start()
    {
        timer = spawnInterval;

        // Si no se repite, spawnea una sola vez
        if (!repeatSpawning)
        {
            SpawnEnemies();
        }
    }

    void Update()
    {
        if (!repeatSpawning) return;

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemies();
            timer = spawnInterval;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 randomPos = spawnCenter + new Vector3(
                Random.Range(-spawnSize.x / 2, spawnSize.x / 2),
                0,
                Random.Range(-spawnSize.z / 2, spawnSize.z / 2)
            );

            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }

    // Opcional: Dibujar el área en la escena
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(spawnCenter, spawnSize);
    }
}
