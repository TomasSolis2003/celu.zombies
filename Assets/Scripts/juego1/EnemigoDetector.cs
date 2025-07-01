using UnityEngine;
using UnityEngine.AI;

public class EnemigoDetector : MonoBehaviour
{
    public Transform jugador; // Se asigna automáticamente al detectar
    public float rangoDeteccion = 10f;

    private NavMeshAgent agente;
    private bool jugadorDetectado = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (jugadorDetectado && jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugador = other.transform;
            jugadorDetectado = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorDetectado = false;
            agente.ResetPath();
        }
    }
}
