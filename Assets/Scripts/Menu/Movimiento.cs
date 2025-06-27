using UnityEngine;

public class MoverDeLadoALado : MonoBehaviour
{
    public Transform puntoA;   // Primer punto de destino
    public Transform puntoB;   // Segundo punto de destino
    public float velocidad = 2f;

    private Transform objetivoActual;

    void Start()
    {
        objetivoActual = puntoB;
    }

    void Update()
    {
        if (puntoA == null || puntoB == null) return;

        // Mover hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual.position, velocidad * Time.deltaTime);

        // Cambiar objetivo si llegamos
        if (Vector3.Distance(transform.position, objetivoActual.position) < 0.01f)
        {
            objetivoActual = (objetivoActual == puntoA) ? puntoB : puntoA;
        }
    }
}
