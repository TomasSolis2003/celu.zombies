
/*using UnityEngine;

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
*/
/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public float repairRate = 2f; // puntos de vida por segundo
    private bool playerNearby = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Reparar autom�ticamente si el jugador est� cerca
        if (playerNearby && currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(repairRate * Time.deltaTime);
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Barricada da�ada: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("�Barricada destruida!");
            // Ac� podr�as activar alg�n efecto visual
        }
    }

    // Detectar si el jugador entra al �rea
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detectar si el jugador sale del �rea
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
*/
/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public float repairRate = 2f; // salud por segundo

    private bool playerNearby = false;
    private Renderer rend;

    private void Start()
    {
        currentHealth = maxHealth;

        // Obtener el material del objeto
        rend = GetComponent<Renderer>();
        if (rend == null)
        {
            Debug.LogWarning("No se encontr� Renderer en la barricada");
        }
    }

    private void Update()
    {
        // Reparar si el jugador est� cerca
        if (playerNearby && currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(repairRate * Time.deltaTime);
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }

        UpdateColor();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Barricada da�ada: " + currentHealth);
    }

    private void UpdateColor()
    {
        if (rend == null) return;

        float healthPercent = (float)currentHealth / maxHealth;

        if (healthPercent > 0.66f)
        {
            rend.material.color = Color.green;
        }
        else if (healthPercent > 0.33f)
        {
            rend.material.color = Color.yellow;
        }
        else
        {
            rend.material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
*/
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public float repairRate = 2f;

    private bool playerNearby = false;
    private Renderer rend;
    private Collider col;

    private void Start()
    {
        currentHealth = maxHealth;

        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        if (rend == null) Debug.LogWarning("Renderer no encontrado en la barricada");
        if (col == null) Debug.LogWarning("Collider no encontrado en la barricada");
    }

    private void Update()
    {
        // Reparaci�n autom�tica si el jugador est� cerca
        if (playerNearby && currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(repairRate * Time.deltaTime);
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }

        UpdateState();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Barricada da�ada: " + currentHealth);
    }

    private void UpdateState()
    {
        float percent = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            // Barricada rota: color negro, se vuelve trigger
            if (rend != null) rend.material.color = Color.black;
            if (col != null) col.isTrigger = true;
        }
        else
        {
            // Cambia el color seg�n la salud
            if (rend != null)
            {
                if (percent > 0.66f)
                    rend.material.color = Color.green;
                else if (percent > 0.33f)
                    rend.material.color = Color.yellow;
                else
                    rend.material.color = Color.red;
            }

            // Si estaba rota y empez� a repararse, vuelve a ser s�lida
            if (col != null && col.isTrigger)
                col.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNearby = false;
    }
}
