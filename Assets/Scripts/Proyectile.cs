

/*using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    public int damage = 1;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemyAI enemyA = other.GetComponent<EnemyAI>();
            if (enemyA != null)
            {
                // Verificamos si el enemigo va a morir
                if (enemyA.health - damage <= 0)
                {
                    // Buscar al jugador por tag y curarlo
                    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                    if (playerObj != null)
                    {
                        PlayerHealth player = playerObj.GetComponent<PlayerHealth>();
                        if (player != null)
                        {
                            player.Heal(5);
                        }
                    }
                }

                enemyA.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
*/
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;
    public int damage = 1;

    private Vector3 moveDirection;

    public void SetDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            EnemyLIBRE enemy = other.GetComponent<EnemyLIBRE>();
            if (enemy != null)
            {
                bool enemyDied = enemy.TakeDamage(damage);

                if (enemyDied)
                {
                    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                    if (playerObj != null)
                    {
                        PlayerHealth player = playerObj.GetComponent<PlayerHealth>();
                        if (player != null)
                        {
                            player.Heal(5);
                        }
                    }
                }

                Destroy(gameObject);
            }
        }
    }
}
