/*using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float boostedFireRate = 0.1f;     // Nueva velocidad de disparo (más rápida)
    public float duration = 5f;              // Duración del efecto en segundos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AutoShooter shooter = other.GetComponent<AutoShooter>();
            if (shooter != null)
            {
                // Iniciar el power-up
                StartCoroutine(BoostFireRate(shooter));
                Debug.Log("🔥 Power-Up de velocidad activado");
                gameObject.SetActive(false); // Ocultar el power-up
            }
        }
    }

    private System.Collections.IEnumerator BoostFireRate(AutoShooter shooter)
    {
        float originalRate = shooter.fireRate;
        shooter.fireRate = boostedFireRate;

        yield return new WaitForSeconds(duration);

        shooter.fireRate = originalRate;
        Debug.Log("💤 Power-Up de velocidad finalizado");
        Destroy(gameObject); // Destruir el objeto del power-up tras usarlo
    }
}*/


using UnityEngine;
using System.Collections;

public class FireRatePowerUp : MonoBehaviour
{
    public float boostedFireRate = 0.1f; // Disparo rápido
    public float duration = 5f;          // Duración del efecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AutoShooter shooter = other.GetComponent<AutoShooter>();
            if (shooter != null)
            {
                shooter.SetFireRate(boostedFireRate, duration);
                Debug.Log("🔥 Power-Up de fuego rápido activado");
                Destroy(gameObject); // Destruye el power-up al usarse
            }
        }
    }
}

/*using UnityEngine;

public class FireRatePowerUp : MonoBehaviour
{
    public float boostedFireRate = 0.1f; // Disparo rápido
    public float duration = 5f;          // Duración del efecto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AutoShooter shooter = other.GetComponent<AutoShooter>();
            if (shooter != null)
            {
                shooter.SetFireRate(boostedFireRate, duration);
                Debug.Log("🔥 Power-Up de fuego rápido activado");

                // Buscar y mostrar el mensaje
                MensajePowerUpUI mensajeUI = FindObjectOfType<MensajePowerUpUI>();
                if (mensajeUI != null)
                {
                    mensajeUI.MostrarContador("VELOCIDAD DE DISPARO", duration);
                }

                Destroy(gameObject);
            }
        }
    }
}*/
