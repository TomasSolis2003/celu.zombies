/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class botonesdedisparo : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float fireRate = 0.5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float fireCooldown = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();
    private int currentTargetIndex = 0;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        UpdateEnemiesInRange();

        // Si el objetivo actual desapareció, reiniciar índice
        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }
    }

    void UpdateEnemiesInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
        enemiesInRange = enemies
            .Where(e => Vector3.Distance(transform.position, e.transform.position) <= detectionRadius)
            .Select(e => e.transform)
            .OrderBy(e => Vector3.Distance(transform.position, e.position))
            .ToList();
    }

    Transform GetCurrentTarget()
    {
        if (enemiesInRange.Count == 0) return null;
        return enemiesInRange[currentTargetIndex];
    }

    // 👉 Llamado desde el botón UI para disparar
    public void DispararAlObjetivoActual()
    {
        if (fireCooldown <= 0f)
        {
            Transform target = GetCurrentTarget();
            if (target != null)
            {
                Shoot(target);
                fireCooldown = fireRate;
            }
        }
    }

    // 👉 Llamado desde el botón UI para cambiar de objetivo
    public void CambiarObjetivo()
    {
        if (enemiesInRange.Count == 0) return;

        currentTargetIndex++;
        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }

        Debug.Log("🔄 Cambiado al enemigo: " + enemiesInRange[currentTargetIndex].name);
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = (target.position - firePoint.position).normalized;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 10f;
            }

            Debug.Log("🎯 Disparando a: " + target.name);
        }
    }

    // Power-up
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

        fireRate = originalRate;
        Debug.Log("⏱️ Power-Up de fuego rápido finalizado");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
*/
/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class botonesdedisparo : MonoBehaviour
{
    [Header("Parámetros de disparo")]
    public float detectionRadius = 10f;
    public float fireRate = 0.5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Indicador de objetivo")]
    public GameObject targetIndicatorPrefab;
    private GameObject currentIndicator;

    private float fireCooldown = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();
    private int currentTargetIndex = 0;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        UpdateEnemiesInRange();
        UpdateIndicatorPosition();
    }

    void UpdateEnemiesInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
        enemiesInRange = enemies
            .Where(e => Vector3.Distance(transform.position, e.transform.position) <= detectionRadius)
            .Select(e => e.transform)
            .OrderBy(e => Vector3.Distance(transform.position, e.position))
            .ToList();

        // Reiniciar el índice si se pasó
        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }

        // Eliminar el indicador si ya no hay enemigos
        if (enemiesInRange.Count == 0 && currentIndicator != null)
        {
            Destroy(currentIndicator);
            currentIndicator = null;
        }
    }

    Transform GetCurrentTarget()
    {
        if (enemiesInRange.Count == 0) return null;
        return enemiesInRange[currentTargetIndex];
    }

    public void DispararAlObjetivoActual()
    {
        if (fireCooldown <= 0f)
        {
            Transform target = GetCurrentTarget();
            if (target != null)
            {
                Shoot(target);
                fireCooldown = fireRate;
            }
        }
    }

    public void CambiarObjetivo()
    {
        if (enemiesInRange.Count == 0) return;

        currentTargetIndex++;
        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }

        Debug.Log("🎯 Objetivo cambiado a: " + GetCurrentTarget().name);
        UpdateIndicatorPosition(true);
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = (target.position - firePoint.position).normalized;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 10f;
            }

            Debug.Log("💥 Disparo al objetivo: " + target.name);
        }
    }

    void UpdateIndicatorPosition(bool forceUpdate = false)
    {
        Transform target = GetCurrentTarget();

        if (target != null)
        {
            Vector3 indicatorPos = target.position + Vector3.up * 2f;

            if (currentIndicator == null && targetIndicatorPrefab != null)
            {
                currentIndicator = Instantiate(targetIndicatorPrefab, indicatorPos, Quaternion.identity);
            }
            else if (currentIndicator != null && (forceUpdate || Vector3.Distance(currentIndicator.transform.position, indicatorPos) > 0.01f))
            {
                currentIndicator.transform.position = indicatorPos;
            }
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

        fireRate = originalRate;
        Debug.Log("⏱️ Power-Up de fuego rápido finalizado");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class botonesdedisparo : MonoBehaviour
{
    [Header("Parámetros de disparo")]
    public float detectionRadius = 10f;
    public float fireRate = 0.5f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Header("Indicador de objetivo")]
    public GameObject targetIndicatorPrefab;
    private GameObject currentIndicator;

    private float fireCooldown = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();
    private int currentTargetIndex = 0;

    // Nuevo: estado del botón de disparo
    private bool isFiring = false;

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        UpdateEnemiesInRange();
        UpdateIndicatorPosition();

        if (isFiring)
        {
            DispararAlObjetivoActual();
        }
    }

    void UpdateEnemiesInRange()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemigo");
        enemiesInRange = enemies
            .Where(e => Vector3.Distance(transform.position, e.transform.position) <= detectionRadius)
            .Select(e => e.transform)
            .OrderBy(e => Vector3.Distance(transform.position, e.position))
            .ToList();

        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }

        if (enemiesInRange.Count == 0 && currentIndicator != null)
        {
            Destroy(currentIndicator);
            currentIndicator = null;
        }
    }

    Transform GetCurrentTarget()
    {
        if (enemiesInRange.Count == 0) return null;
        return enemiesInRange[currentTargetIndex];
    }

    public void DispararAlObjetivoActual()
    {
        if (fireCooldown <= 0f)
        {
            Transform target = GetCurrentTarget();
            if (target != null)
            {
                Shoot(target);
                fireCooldown = fireRate;
            }
        }
    }

    public void CambiarObjetivo()
    {
        if (enemiesInRange.Count == 0) return;

        currentTargetIndex++;
        if (currentTargetIndex >= enemiesInRange.Count)
        {
            currentTargetIndex = 0;
        }

        Debug.Log("🎯 Objetivo cambiado a: " + GetCurrentTarget().name);
        UpdateIndicatorPosition(true);
    }

    void Shoot(Transform target)
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Vector3 direction = (target.position - firePoint.position).normalized;

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * 10f;
            }

            Debug.Log("💥 Disparo al objetivo: " + target.name);
        }
    }
    void UpdateIndicatorPosition(bool forceUpdate = false)
    {
        Transform target = GetCurrentTarget();

        if (target != null)
        {
            Vector3 indicatorPos = target.position + Vector3.up * 2f;

            if (currentIndicator == null && targetIndicatorPrefab != null)
            {
                currentIndicator = Instantiate(targetIndicatorPrefab, indicatorPos, Quaternion.identity);
            }
            else if (currentIndicator != null)
            {
                // Siempre sigue al objetivo
                currentIndicator.transform.position = indicatorPos;
            }
        }
        else
        {
            // Si no hay objetivo, destruimos el indicador
            if (currentIndicator != null)
            {
                Destroy(currentIndicator);
                currentIndicator = null;
            }
        }
    }

    /*void UpdateIndicatorPosition(bool forceUpdate = false)
     {
         Transform target = GetCurrentTarget();

         if (target != null)
         {
             Vector3 indicatorPos = target.position + Vector3.up * 2f;

             if (currentIndicator == null && targetIndicatorPrefab != null)
             {
                 currentIndicator = Instantiate(targetIndicatorPrefab, indicatorPos, Quaternion.identity);
             }
             else if (currentIndicator != null && (forceUpdate || Vector3.Distance(currentIndicator.transform.position, indicatorPos) > 0.01f))
             {
                 currentIndicator.transform.position = indicatorPos;
             }
         }
     }*/

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

        fireRate = originalRate;
        Debug.Log("⏱️ Power-Up de fuego rápido finalizado");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    // 🔘 Estos métodos se llaman desde el botón del Canvas (con EventTrigger)
    public void StartFiring()
    {
        isFiring = true;
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
