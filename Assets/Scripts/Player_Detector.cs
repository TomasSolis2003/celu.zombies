/*using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public Barricade barricadeToRepair; // Asignar manualmente en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(true);
            Debug.Log("Jugador detectado. Reparaci�n iniciada.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(false);
            Debug.Log("Jugador sali� del �rea.");
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
            Debug.Log("Jugador detectado en zona de reparaci�n.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && barricadeToRepair != null)
        {
            barricadeToRepair.SetPlayerNearby(false);
            Debug.Log("Jugador sali� de la zona de reparaci�n.");
        }
    }
}
