/*using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Barricade barricadeToRepair; // Asignar manualmente en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(true);
            Debug.Log("Jugador detectado. Reparación iniciada.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(false);
            Debug.Log("Jugador salió del área.");
        }
    }
}
*/
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Barricade barricadeToRepair;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(true);
            Debug.Log("Jugador detectado en zona de reparación.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(false);
            Debug.Log("Jugador salió de la zona de reparación.");
        }
    }
}
