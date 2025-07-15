/*using UnityEngine;

public class OrbShop : MonoBehaviour
{
    public GameObject orbPrefab; // Prefab de la esfera giratoria
    public Transform player;     // Referencia al jugador
    public int orbCost = 30;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.X))
        {
            if (GameManager.Instance.GastarPuntos(orbCost))
            {
                GameObject orb = Instantiate(orbPrefab);
                OrbitalSphere os = orb.GetComponent<OrbitalSphere>();
                os.target = player; // Hacerla orbitar alrededor del jugador

                Debug.Log("¡Esfera comprada!");
            }
            else
            {
                Debug.Log("No tienes puntos suficientes.");
            }
        }
    }
}
*/
/*using UnityEngine;

public class OrbShop : MonoBehaviour
{
    public GameObject orbPrefab;  // Prefab del orbe
    public Transform player;      // Referencia al jugador
    public int orbCost = 30;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.GastarPuntos(orbCost))
            {
                GameObject orb = Instantiate(orbPrefab);
                OrbitalSphere os = orb.GetComponent<OrbitalSphere>();
                os.target = player;

                Debug.Log("¡Orbe comprado automáticamente!");
            }
            else
            {
                Debug.Log("No tienes puntos suficientes para comprar el orbe.");
            }
        }
    }
}
*/
using UnityEngine;

public class OrbShop : MonoBehaviour
{
    public GameObject orbPrefab;  // Prefab del orbe
    public Transform player;      // Referencia al jugador
    public int orbCost = 30;
    public int maxOrbs = 4;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Contar cuántos orbes existen actualmente orbitando al jugador
            OrbitalSphere[] orbesActuales = FindObjectsOfType<OrbitalSphere>();
            int cantidadActual = 0;

            foreach (var orb in orbesActuales)
            {
                if (orb.target == player)
                    cantidadActual++;
            }

            // Si no superó el límite, permitir compra
            if (cantidadActual < maxOrbs)
            {
                if (GameManager.Instance.GastarPuntos(orbCost))
                {
                    GameObject orb = Instantiate(orbPrefab);
                    orb.GetComponent<OrbitalSphere>().target = player;

                    Debug.Log("¡Orbe comprado!");
                }
                else
                {
                    Debug.Log("No tienes puntos suficientes para comprar el orbe.");
                }
            }
            else
            {
                Debug.Log("¡Ya tenés el máximo de orbes permitidos!");
            }
        }
    }
}
