/*using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // Asignar en el inspector
    public PlayerHealth playerHealth; // Asignar en el inspector

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("Falta asignar PlayerHealth al HealthBarUI.");
            return;
        }

        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.currentHealth;
    }

    void Update()
    {
        healthSlider.value = playerHealth.currentHealth;
    }
}
*/
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider; // Asignar en el inspector
    public Image fillImage;     // La imagen de "Fill" del Slider

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        UpdateColor(currentHealth, maxHealth);
    }

    private void UpdateColor(int currentHealth, int maxHealth)
    {
        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.6f)
            fillImage.color = Color.green;
        else if (healthPercent > 0.3f)
            fillImage.color = Color.yellow;
        else
            fillImage.color = Color.red;
    }
}
