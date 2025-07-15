using UnityEngine;

public class TurretShop : MonoBehaviour
{
    public GameObject turretPrefab;
    public Transform spawnPoint;
    public int turretCost = 100;

    private Turret instancia;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (instancia == null)
            {
                if (GameManager.Instance.GastarPuntos(turretCost))
                {
                    GameObject t = Instantiate(turretPrefab, spawnPoint.position, Quaternion.identity);
                    instancia = t.GetComponent<Turret>();
                    Debug.Log("Torreta colocada.");
                }
            }
            else
            {
                if (!instancia.EstaActiva())
                {
                    if (GameManager.Instance.GastarPuntos(turretCost))
                    {
                        instancia.Reactivar();
                        Debug.Log("Torreta reactivada.");
                    }
                }
                else
                {
                    Debug.Log("Ya hay una torreta activa.");
                }
            }
        }
    }
}
