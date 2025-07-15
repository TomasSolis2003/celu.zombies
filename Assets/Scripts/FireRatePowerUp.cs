


using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    [Header("Configuración del Power-Up")]
    public float boostedFireRate = 0.1f; // Disparo cada 0.1s
    public float duration = 5f;          // Duración del efecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonesdedisparo shooter = other.GetComponent<botonesdedisparo>();
            if (shooter != null)
            {
                shooter.SetFireRate(boostedFireRate, duration);
                Debug.Log("🚀 Power-Up de disparo rápido activado");
                Destroy(gameObject); // Elimina el Power-Up después de activarse
            }
        }
    }
}

/*using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float boostedFireRate = 0.1f;
    public float duration = 5f;

    public PowerUpUI powerUpUI; // Asignar en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            botonesdedisparo shooter = other.GetComponent<botonesdedisparo>();
            if (shooter != null)
            {
                shooter.SetFireRate(boostedFireRate, duration);
                Debug.Log("🚀 Power-Up de disparo rápido activado");

                if (powerUpUI != null)
                {
                    powerUpUI.ShowPowerUpMessage("VELOCIDAD DE DISPARO AUMENTADA", duration);
                }

                Destroy(gameObject);
            }
        }
    }
}
*/