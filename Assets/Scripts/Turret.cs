/*using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public int killLimit = 50;
    private int currentKills = 0;
    private float fireCooldown = 0f;
    private bool activa = true;

    void Update()
    {
        if (!activa) return;

        fireCooldown -= Time.deltaTime;

        GameObject target = BuscarEnemigoMasCercano();

        if (target != null && fireCooldown <= 0f)
        {
            Disparar(target);
            fireCooldown = 1f / fireRate;
        }
    }

    GameObject BuscarEnemigoMasCercano()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject objetivo = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMinima && distancia <= range)
            {
                distanciaMinima = distancia;
                objetivo = enemigo;
            }
        }

        return objetivo;
    }

    void Disparar(GameObject target)
    {
        GameObject bala = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(target.transform.position - firePoint.position));
        bala.GetComponent<Projectile>().SetTurret(this); // Pasar referencia a la torreta
    }

    public void ContarMuerte()
    {
        currentKills++;
        if (currentKills >= killLimit)
        {
            activa = false;
            Debug.Log("La torreta alcanzó su límite de enemigos y se desactivó.");
        }
    }

    public void Reactivar()
    {
        currentKills = 0;
        activa = true;
        Debug.Log("¡Torreta reactivada!");
    }

    public bool EstaActiva()
    {
        return activa;
    }
}
*/
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float range = 10f;
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    public int killLimit = 50;
    private int currentKills = 0;
    private float fireCooldown = 0f;
    private bool activa = true;

    void Update()
    {
        if (!activa) return;

        fireCooldown -= Time.deltaTime;

        GameObject target = BuscarEnemigoMasCercano();

        if (target != null && fireCooldown <= 0f)
        {
            Disparar(target);
            fireCooldown = 1f / fireRate;
        }
    }

    GameObject BuscarEnemigoMasCercano()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        GameObject objetivo = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia < distanciaMinima && distancia <= range)
            {
                distanciaMinima = distancia;
                objetivo = enemigo;
            }
        }

        return objetivo;
    }

    void Disparar(GameObject target)
    {
        GameObject bala = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(target.transform.position - firePoint.position));

        // 🔄 Aquí usamos tu clase personalizada BalaTorreta
        bala.GetComponent<BalaTorreta>().SetTurret(this);
    }

    public void ContarMuerte()
    {
        currentKills++;
        if (currentKills >= killLimit)
        {
            activa = false;
            Debug.Log("La torreta alcanzó su límite de enemigos y se desactivó.");
        }
    }

    public void Reactivar()
    {
        currentKills = 0;
        activa = true;
        Debug.Log("¡Torreta reactivada!");
    }

    public bool EstaActiva()
    {
        return activa;
    }
}
