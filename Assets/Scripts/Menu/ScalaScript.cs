using UnityEngine;

public class CambiarEscala : MonoBehaviour
{
    public Vector3 escalaInicial = new Vector3(1, 1, 1);
    public Vector3 escalaFinal = new Vector3(2, 2, 2);
    public float velocidad = 2f;
    public bool repetir = true;

    private bool haciaFinal = true;

    void Update()
    {
        Vector3 destino = haciaFinal ? escalaFinal : escalaInicial;
        transform.localScale = Vector3.Lerp(transform.localScale, destino, Time.deltaTime * velocidad);

        // Si está cerca del destino, cambiar la dirección
        if (Vector3.Distance(transform.localScale, destino) < 0.01f && repetir)
        {
            haciaFinal = !haciaFinal;
        }
    }
}
