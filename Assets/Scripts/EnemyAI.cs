/*using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int health = 10;
    public int damage = 1;

    // Método para recibir daño
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject); // Destruye al enemigo
        }
    }

    // Esto puedes expandirlo si quieres que persiga al jugador
    void Update()
    {
        if (target != null)
        {
            // Movimiento simple hacia el jugador
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }
    }

    // Este método se llama desde el trigger hijo al detectar barricadas
    public void HitBarricade(Barricade barricade)
    {
        barricade.TakeDamage(damage);
    }
}
*/
/*using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int health = 10;
    public int damage = 1;

    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
*/
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public int health = 10;
    public int damage = 1;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float attackTimer = 0f;
    private void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }

    
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);

                float distance = Vector3.Distance(transform.position, target.position);

                // Verificar si el jugador está en rango de ataque
                if (distance <= attackRange)
                {
                    attackTimer -= Time.deltaTime;

                    if (attackTimer <= 0f)
                    {
                        PlayerHealth player = target.GetComponent<PlayerHealth>();
                        if (player != null)
                        {
                            player.TakeDamage(damage);
                            attackTimer = attackCooldown;
                        }
                    }
                }
            }
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // ✅ Método que causaba el error por estar ausente
    public void HitBarricade(Barricade barricade)
    {
        if (barricade != null)
        {
            barricade.TakeDamage(damage);
        }
    }
   
}
