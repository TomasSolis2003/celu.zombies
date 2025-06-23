using UnityEngine;
using System.Collections;
public class AutoShooter : MonoBehaviour
{
    public float detectionRadius = 10f;         // Radio de detección
    public float fireRate = 0.5f;               // Tiempo entre disparos
    public GameObject projectilePrefab;         // Prefab del proyectil
    public Transform firePoint;                 // Punto desde el cual se dispara

    private float fireCooldown = 0f;
    private Transform currentTarget;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        // Buscar enemigo más cercano dentro del radio
        currentTarget = GetClosestEnemy();

        // Si hay un enemigo y se puede disparar
        if (currentTarget != null && fireCooldown <= 0f)
        {
            Shoot(currentTarget);
            fireCooldown = fireRate;
        }
    }
    public void SetFireRate(float newRate, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(TemporaryFireRate(newRate, duration));
    }

    private IEnumerator TemporaryFireRate(float newRate, float duration)
    {
        float originalRate = fireRate;
        fireRate = newRate;

        yield return new WaitForSeconds(duration);

        fireRate = 0.3f; // Valor predeterminado al terminar el power-up
        Debug.Log("⏱️ Power-Up de fuego rápido finalizado");
    }
    Transform GetClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
        Transform closest = null;
        float minDistance = detectionRadius;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= detectionRadius && distance < minDistance)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Direccion al objetivo
            Vector3 direction = (target.position - firePoint.position).normalized;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 10f; // Velocidad del proyectil
            }
        }
    }

    // Dibujar el radio de detección en el editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
