/*using UnityEngine;
using System.Collections;

public class MovimientoSecuencial : MonoBehaviour
{
    [Header("Puntos de destino")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    [Header("Jugador")]
    public string tagJugador = "Player";

    [Header("Parámetros de movimiento")]
    public float velocidad = 2f;
    public float esperaEnB = 30f;

    private bool jugadorDentro = false;
    private bool movimientoIniciado = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            jugadorDentro = true;

            if (!movimientoIniciado)
            {
                StartCoroutine(SecuenciaMovimiento());
            }
        }
    }

    IEnumerator SecuenciaMovimiento()
    {
        movimientoIniciado = true;

        // Paso 1: mover de A a B
        yield return StartCoroutine(MoverHasta(puntoB.position));

        // Paso 2: esperar en B
        yield return new WaitForSeconds(esperaEnB);

        // Paso 3: mover de B a C
        yield return StartCoroutine(MoverHasta(puntoC.position));

        Debug.Log("🚉 Llegaste a la estación final (C)");
    }

    IEnumerator MoverHasta(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }
}
*/
/*using UnityEngine;
using System.Collections;

public class MovimientoSecuencialConBloqueo : MonoBehaviour
{
    [Header("Puntos de destino")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    [Header("Jugador")]
    public string tagJugador = "Player";

    [Header("Bloqueo del jugador")]
    public Collider barreraJugador; // objeto que bloquea la salida del jugador

    [Header("Parámetros de movimiento")]
    public float velocidad = 2f;
    public float esperaEnB = 30f;

    private bool jugadorDentro = false;
    private bool movimientoIniciado = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            jugadorDentro = true;

            if (!movimientoIniciado)
            {
                StartCoroutine(SecuenciaMovimiento());
            }
        }
    }

    IEnumerator SecuenciaMovimiento()
    {
        movimientoIniciado = true;

        // Activar bloqueo para que el jugador no pueda salir
        if (barreraJugador != null)
            barreraJugador.enabled = true;

        // Paso 1: mover de A a B
        yield return StartCoroutine(MoverHasta(puntoB.position));

        // Esperar en B
        yield return new WaitForSeconds(esperaEnB);

        // Paso 2: mover de B a C
        yield return StartCoroutine(MoverHasta(puntoC.position));

        // 🚪 Al llegar al destino, permitir que el jugador salga
        if (barreraJugador != null)
            barreraJugador.enabled = false;

        Debug.Log("🚉 Estación final alcanzada. El jugador puede salir.");
    }

    IEnumerator MoverHasta(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }
}
*/
using UnityEngine;
using System.Collections;

public class MovimientoSecuencialConBloqueo : MonoBehaviour
{
    [Header("Puntos de destino")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    [Header("Jugador")]
    public string tagJugador = "Player";

    [Header("Bloqueo del jugador")]
    public Collider barreraJugador; // objeto que bloquea la salida del jugador

    [Header("Parámetros de movimiento")]
    public float velocidad = 2f;
    public float esperaEnB = 30f;

    private bool jugadorDentro = false;
    private bool movimientoIniciado = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            jugadorDentro = true;

            if (!movimientoIniciado)
            {
                StartCoroutine(SecuenciaMovimiento());
            }
        }
    }

    IEnumerator SecuenciaMovimiento()
    {
        movimientoIniciado = true;

        // Activar bloqueo para que el jugador no pueda salir
        if (barreraJugador != null)
            barreraJugador.enabled = true;

        // Paso 1: mover de A a B
        yield return StartCoroutine(MoverHasta(puntoB.position));

        // Esperar en B
        yield return new WaitForSeconds(esperaEnB);

        // Paso 2: mover de B a C
        yield return StartCoroutine(MoverHasta(puntoC.position));

        // 🚪 Al llegar al destino, permitir que el jugador salga
        if (barreraJugador != null)
            barreraJugador.enabled = false;

        Debug.Log("🚉 Estación final alcanzada. El jugador puede salir.");
    }

    IEnumerator MoverHasta(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }
}
