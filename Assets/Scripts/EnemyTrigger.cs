/*using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private EnemyAI enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemyAI>();
    }

    void OnTriggerEnter(Collider other)
    {
        Barricade barricade = other.GetComponent<Barricade>();
        if (barricade != null)
        {
           // enemy.HitBarricade(barricade);
        }
    }
}
*/
/*using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private EnemyAI enemy;
    private Barricade currentBarricade;
    private float damageTimer = 0f;
    public float damageInterval = 1f;

    void Start()
    {
        enemy = GetComponentInParent<EnemyAI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Barricade barricade))
        {
            currentBarricade = barricade;
            damageTimer = damageInterval; // Fuerza daño inmediato al tocar
        }
    }


    public void HitBarricade(Barricade barricade)
{
    if (barricade != null)
    {
        barricade.TakeDamage(damage);
    }
}
    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Barricade barricade) && barricade == currentBarricade)
        {
            currentBarricade = null;
        }
    }
}*/
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private EnemyAI enemy;
    private Barricade currentBarricade;
    private float damageTimer = 0f;
    public float damageInterval = 1f;

    void Start()
    {
        enemy = GetComponentInParent<EnemyAI>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Barricade barricade))
        {
            currentBarricade = barricade;
            damageTimer = damageInterval; // Hacer daño inmediato
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (currentBarricade != null)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                currentBarricade.TakeDamage(enemy.damage);
                damageTimer = damageInterval;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Barricade barricade) && barricade == currentBarricade)
        {
            currentBarricade = null;
        }
    }
}

