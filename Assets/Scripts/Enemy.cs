using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public GameObject healthPowerUpPrefab; // Prefab del power-up
    public float dropChance = 1.0f; // 1.0 = 100% de probabilidad

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Probabilidad de soltar el power-up
        if (Random.value <= dropChance && healthPowerUpPrefab != null)
        {
            Instantiate(healthPowerUpPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Destruye al enemigo
    }
}