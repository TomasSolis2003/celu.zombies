using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 50;
    public int currentHealth;

    private bool isDead = false;

    [Header("UI")]
    public Slider healthSlider;
    public Image fillImage; // Imagen de "Fill" del slider para cambiar el color

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Salud del jugador: " + currentHealth);

        UpdateHealthBar();

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

        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;

            UpdateBarColor();
        }
    }

    void UpdateBarColor()
    {
        if (fillImage == null) return;

        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.6f)
            fillImage.color = Color.green;
        else if (healthPercent > 0.3f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;
    }

    void Die()
    {
        isDead = true;
        Debug.Log("¡El jugador ha muerto!");
        Destroy(gameObject);
    }
}
