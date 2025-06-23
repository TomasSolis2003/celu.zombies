using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;     // Prefab del power-up
    public float spawnInterval = 15f;    // Cada cuánto tiempo se genera
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f); // Zona de spawn

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnPowerUp();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnPowerUp()
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            spawnAreaSize.y,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Instantiate(powerUpPrefab, randomPosition, Quaternion.identity);
    }

    // Mostrar el área de spawn en el editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + spawnAreaSize / 2, spawnAreaSize);
    }
}
