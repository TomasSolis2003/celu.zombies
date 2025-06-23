/*using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Jugador recibió daño. Salud restante: " + health);

        if (health <= 0)
        {
            Debug.Log("¡Jugador muerto!");
            // Aquí podrías activar Game Over o reiniciar
        }
    }
}
*/
/*using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Jugador recibió daño. Salud restante: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Jugador eliminado!");
        Destroy(gameObject);
    }
}
*/
/*using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Salud del jugador: " + currentHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log("Jugador curado: " + currentHealth);
    }

}
*/
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Salud del jugador: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        Debug.Log("Jugador curado: " + currentHealth);
    }

    void Die()
    {
        isDead = true;
        Debug.Log("¡El jugador ha muerto!");
        Destroy(gameObject); // Destruir jugador al morir
    }
}
