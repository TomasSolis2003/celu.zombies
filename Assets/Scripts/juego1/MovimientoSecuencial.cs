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
/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoSecuencialConPuertas : MonoBehaviour
{
    [Header("Puntos de destino")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    [Header("Jugador")]
    public string tagJugador = "Player";

    [Header("Puertas a controlar")]
    public List<Transform> puertas; // objetos que cambian de escala (eje Y)
    public float alturaAbajo = 0.1f;
    public float alturaArriba = 2f;
    public float duracionAnimacion = 1f;

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

        // Bajar puertas en B
        yield return StartCoroutine(CambiarAlturaPuertas(alturaAbajo));

        // Esperar en B
        yield return new WaitForSeconds(esperaEnB);

        // Subir puertas de nuevo
        yield return StartCoroutine(CambiarAlturaPuertas(alturaArriba));

        // Paso 2: mover de B a C
        yield return StartCoroutine(MoverHasta(puntoC.position));

        // Bajar puertas y dejarlas abajo para siempre
        yield return StartCoroutine(CambiarAlturaPuertas(alturaAbajo));

        Debug.Log("🚉 Estación final alcanzada. Puertas bajadas permanentemente.");
    }

    IEnumerator MoverHasta(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CambiarAlturaPuertas(float nuevaAltura)
    {
        float t = 0f;
        List<Vector3> escalaInicial = new List<Vector3>();
        List<Vector3> escalaObjetivo = new List<Vector3>();

        foreach (var puerta in puertas)
        {
            escalaInicial.Add(puerta.localScale);
            Vector3 destino = new Vector3(
                puerta.localScale.x,
                nuevaAltura,
                puerta.localScale.z
            );
            escalaObjetivo.Add(destino);
        }

        while (t < duracionAnimacion)
        {
            t += Time.deltaTime / duracionAnimacion;
            for (int i = 0; i < puertas.Count; i++)
            {
                puertas[i].localScale = Vector3.Lerp(escalaInicial[i], escalaObjetivo[i], t);
            }
            yield return null;
        }
    }
}
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoSecuencialConPuertas : MonoBehaviour
{
    [Header("Puntos de destino")]
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    [Header("Jugador")]
    public string tagJugador = "Player";

    [Header("Barrera Final (fuera del tren)")]
    public Transform barreraFinal;
    public Vector3 posicionFinalBarrera;
    public float velocidadBarrera = 2f;

    [Header("Puertas a controlar")]
    public List<Transform> puertas; // objetos que cambian de escala (eje Y)
    public float alturaAbajo = 0.1f;
    public float alturaArriba = 2f;
    public float duracionAnimacion = 1f;

    [Header("Parámetros de movimiento")]
    public float velocidad = 2f;
    public float esperaEnB = 30f;

    private bool jugadorDentro = false;
    private bool movimientoIniciado = false;

    void Start()
    {
        // 🔽 Al inicio, las puertas están abajo (abiertas)
        SetPuertasAlturaInstantanea(alturaAbajo);
    }

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

        // 🔼 Subir puertas al iniciar
        yield return StartCoroutine(CambiarAlturaPuertas(alturaArriba));

        // ➡️ Mover de A a B
        yield return StartCoroutine(MoverHasta(puntoB.position));

        // 🔽 Bajar puertas en B
        yield return StartCoroutine(CambiarAlturaPuertas(alturaAbajo));

        // 🕒 Esperar en B
        yield return new WaitForSeconds(esperaEnB);

        // 🔼 Subir puertas de nuevo
        yield return StartCoroutine(CambiarAlturaPuertas(alturaArriba));

        // ➡️ Mover de B a C
        yield return StartCoroutine(MoverHasta(puntoC.position));

        // 🔽 Bajar puertas y dejarlas abiertas para siempre
        yield return StartCoroutine(CambiarAlturaPuertas(alturaAbajo));

        // 🔽 Bajar barrera final
        if (barreraFinal != null)
        {
            StartCoroutine(BajarBarreraFinal());
        }

        Debug.Log("🚉 Estación final alcanzada. Puertas bajadas permanentemente.");
    }

    IEnumerator MoverHasta(Vector3 destino)
    {
        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator CambiarAlturaPuertas(float nuevaAltura)
    {
        float t = 0f;
        List<Vector3> escalaInicial = new List<Vector3>();
        List<Vector3> escalaObjetivo = new List<Vector3>();

        foreach (var puerta in puertas)
        {
            escalaInicial.Add(puerta.localScale);
            Vector3 destino = new Vector3(
                puerta.localScale.x,
                nuevaAltura,
                puerta.localScale.z
            );
            escalaObjetivo.Add(destino);
        }

        while (t < 1f)
        {
            t += Time.deltaTime / duracionAnimacion;
            for (int i = 0; i < puertas.Count; i++)
            {
                puertas[i].localScale = Vector3.Lerp(escalaInicial[i], escalaObjetivo[i], t);
            }
            yield return null;
        }
    }

    // 🔧 Aplica una altura inmediata sin animación (para el Start)
    void SetPuertasAlturaInstantanea(float altura)
    {
        foreach (var puerta in puertas)
        {
            if (puerta != null)
            {
                puerta.localScale = new Vector3(
                    puerta.localScale.x,
                    altura,
                    puerta.localScale.z
                );
            }
        }
    }
    IEnumerator BajarBarreraFinal()
    {
        Debug.Log("🔓 Bajando barrera final...");

        while (Vector3.Distance(barreraFinal.position, posicionFinalBarrera) > 0.05f)
        {
            barreraFinal.position = Vector3.MoveTowards(
                barreraFinal.position,
                posicionFinalBarrera,
                velocidadBarrera * Time.deltaTime
            );
            yield return null;
        }

        Debug.Log("✅ Barrera final bajada completamente.");
    }

}
