/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int health = 20;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject); // Destruye la barricada
        }
    }
}
*/
/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int health = 20;

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

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Repair(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
