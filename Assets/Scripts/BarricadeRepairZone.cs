using UnityEngine;

public class BarricadeRepairZone : MonoBehaviour
{
    public Barricade barricadeToRepair;
    public int repairAmount = 1;
    public float repairInterval = 1f;

    private float repairTimer = 0f;
    private bool playerInZone = false;

    void Update()
    {
        if (playerInZone && barricadeToRepair != null)
        {
            repairTimer -= Time.deltaTime;
            if (repairTimer <= 0f)
            {
                barricadeToRepair.Repair(repairAmount);
                repairTimer = repairInterval;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            repairTimer = 0f; // Reparar de inmediato al entrar
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}
