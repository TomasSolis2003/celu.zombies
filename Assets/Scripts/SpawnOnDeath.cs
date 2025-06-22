using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    public GameObject smallEnemyPrefab;  // Prefab del enemigo peque�o
    public int spawnCount = 4;           // Cu�ntos enemigos peque�os crear
    public float spawnRadius = 1.5f;     // Radio aleatorio alrededor del objeto destruido

    private bool hasSpawned = false;     // Para evitar m�ltiples ejecuciones

    void OnDestroy()
    {
        // Evita que se ejecute m�s de una vez (por ejemplo, si hay efectos en cadena)
        if (hasSpawned) return;
        hasSpawned = true;

        for (int i = 0; i < spawnCount; i++)
        {
            // Posici�n aleatoria alrededor del objeto destruido
            Vector3 offset = Random.insideUnitSphere * spawnRadius;
            offset.y = 0; // Opcional: evitar que aparezcan en el aire

            Vector3 spawnPos = transform.position + offset;
            Instantiate(smallEnemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
