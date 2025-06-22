

/*using UnityEngine;

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
    public void SetPlayerNearby(bool state)
    {
        playerNearby = state;
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
*/
/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public float repairRate = 2f;
    private float repairCooldown = 2f;
    private float repairTimer = 0f;
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

    public void SetPlayerNearby(bool state)
    {
        playerNearby = state;
    }

    private void Update()
    {
        if (playerNearby && currentHealth < maxHealth)
        {
            currentHealth += Mathf.RoundToInt(repairRate * Time.deltaTime);
            currentHealth = Mathf.Min(currentHealth, maxHealth);
        }
        if (playerNearby && currentHealth < maxHealth)
        {
            repairTimer -= Time.deltaTime;
            if (repairTimer <= 0f)
            {
                currentHealth += 1;
                repairTimer = repairCooldown;
            }
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
            if (rend != null) rend.material.color = Color.black;
            if (col != null) col.isTrigger = true;
        }
        else
        {
            if (rend != null)
            {
                if (percent > 0.66f)
                    rend.material.color = Color.green;
                else if (percent > 0.33f)
                    rend.material.color = Color.yellow;
                else
                    rend.material.color = Color.red;
            }

            if (col != null && col.isTrigger)
                col.isTrigger = false;
        }
    }
}
*/
/*using UnityEngine;

public class Barricade : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public float repairCooldown = 1.5f; // Tiempo entre reparaciones
    public int repairAmount = 5;        // Cu�nto se repara cada vez

    private float repairTimer = 0f;
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

    public void SetPlayerNearby(bool state)
    {
        playerNearby = state;
    }

    private void Update()
    {
        if (playerNearby && currentHealth < maxHealth)
        {
            repairTimer -= Time.deltaTime;

            if (repairTimer <= 0f)
            {
                currentHealth += repairAmount;
                currentHealth = Mathf.Min(currentHealth, maxHealth);
                repairTimer = repairCooldown;
            }
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
            if (rend != null) rend.material.color = Color.black;
            if (col != null) col.isTrigger = true;
        }
        else
        {
            if (rend != null)
            {
                if (percent > 0.66f)
                    rend.material.color = Color.green;
                else if (percent > 0.33f)
                    rend.material.color = Color.yellow;
                else
                    rend.material.color = Color.red;
            }

            if (col != null && col.isTrigger)
                col.isTrigger = false;
        }
    }
}
*/
using UnityEngine;

public class Barricade : MonoBehaviour
{
    // Vida m�xima de la barricada
    public int maxHealth = 100;
    // Vida actual de la barricada
    public int currentHealth;

    // Tiempo en segundos que tarda en repararse cada vez
    public float repairCooldown = 1.5f;
    // Cantidad de vida que se recupera en cada reparaci�n
    public int repairAmount = 5;

    // Temporizador interno para controlar el cooldown de reparaci�n
    private float repairTimer = 0f;
    // Estado que indica si el jugador est� cerca para reparar
    private bool playerNearby = false;

    // Referencia al Renderer para cambiar color seg�n salud
    private Renderer rend;
    // Referencia al Collider para activar/desactivar el trigger
    private Collider col;

    private void Start()
    {
        // Inicializamos la vida con la m�xima
        currentHealth = maxHealth;

        // Obtenemos referencias a componentes
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        // Advertencias en caso de que no existan estos componentes
        if (rend == null) Debug.LogWarning("Renderer no encontrado en la barricada");
        if (col == null) Debug.LogWarning("Collider no encontrado en la barricada");
    }

    // M�todo p�blico para que el objeto hijo detecte si el jugador est� cerca
    public void SetPlayerNearby(bool state)
    {
        playerNearby = state;
    }

    private void Update()
    {
        // Si el jugador est� cerca y la barricada no est� al m�ximo de vida
        if (playerNearby && currentHealth < maxHealth)
        {
            // Reducimos el tiempo del cooldown
            repairTimer -= Time.deltaTime;

            // Cuando el cooldown llegue a cero o menos, reparamos
            if (repairTimer <= 0f)
            {
                // Sumamos vida seg�n el repairAmount
                currentHealth += repairAmount;
                // Aseguramos que la vida no pase del m�ximo
                currentHealth = Mathf.Min(currentHealth, maxHealth);
                // Reiniciamos el temporizador
                repairTimer = repairCooldown;
            }
        }

        // Actualizamos el estado visual y f�sico de la barricada
        UpdateState();
    }

    // M�todo para recibir da�o
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);
        Debug.Log("Barricada da�ada: " + currentHealth);
    }

    // Actualiza el color y el estado del collider seg�n la vida actual
    private void UpdateState()
    {
        float percent = (float)currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            // Si est� destruida, cambia el color a negro
            if (rend != null) rend.material.color = Color.black;
            // Y el collider se vuelve trigger para que enemigos puedan pasar
            if (col != null) col.isTrigger = true;
        }
        else
        {
            // Cambia el color seg�n porcentaje de vida restante
            if (rend != null)
            {
                if (percent > 0.99f)
                    rend.material.color = Color.green;  // Salud alta
                else if (percent > 0.55f)
                    rend.material.color = Color.yellow; // Salud media
                else
                    rend.material.color = Color.red;    // Salud baja
            }

            // Si estaba rota y el collider era trigger, lo vuelve s�lido otra vez
            if (col != null && col.isTrigger)
                col.isTrigger = false;
        }
    }
}
