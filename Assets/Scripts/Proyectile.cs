

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
*/
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
        // Detecta enemigos normales
        if (other.CompareTag("Enemigo"))
        {
            EnemyLIBRE enemy = other.GetComponent<EnemyLIBRE>();
            if (enemy != null)
            {
                bool enemyDied = enemy.TakeDamage(damage);

                if (enemyDied)
                {
                    CurarJugador();
                }

                Destroy(gameObject);
                return;
            }
        }

        // Detecta jefe
        if (other.CompareTag("Jefe"))
        {
            JEFELIBRE boss = other.GetComponent<JEFELIBRE>();
            if (boss != null)
            {
                bool bossDied = boss.TakeDamage(damage);

                if (bossDied)
                {
                    CurarJugador();
                }

                Destroy(gameObject);
            }
        }
    }

    void CurarJugador()
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
            // Intentar dañar enemigo normal
            EnemyLIBRE enemy = other.GetComponent<EnemyLIBRE>();
            if (enemy != null)
            {
                bool enemyDied = enemy.TakeDamage(damage);

                if (enemyDied)
                {
                    CurarJugador();
                }

                Destroy(gameObject);
                return;
            }

            // Intentar dañar al jefe si no era un enemigo normal
            JEFELIBRE boss = other.GetComponent<JEFELIBRE>();
            if (boss != null)
            {
                bool bossDied = boss.TakeDamage(damage);

                if (bossDied)
                {
                    CurarJugador();
                }

                Destroy(gameObject);
                return;
            }
        }
    }

    void CurarJugador()
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
}
