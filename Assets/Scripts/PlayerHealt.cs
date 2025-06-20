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
using UnityEngine;

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
