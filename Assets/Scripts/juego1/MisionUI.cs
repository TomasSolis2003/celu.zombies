/*using UnityEngine;
using TMPro;

public class MisionUI : MonoBehaviour
{
    public TextMeshProUGUI mensajeTMP;
    public float duracionMensaje = 4f;

    private void Start()
    {
        // Opcional: mostrar automáticamente una misión al iniciar
        MostrarMensaje("Nueva misión: Derrota a todos los enemigos");
    }

    public void MostrarMensaje(string texto)
    {
        StopAllCoroutines(); // por si se llama varias veces seguidas
        mensajeTMP.text = texto;
        mensajeTMP.gameObject.SetActive(true);
        StartCoroutine(DesaparecerMensaje());
    }

    private System.Collections.IEnumerator DesaparecerMensaje()
    {
        yield return new WaitForSeconds(duracionMensaje);
        mensajeTMP.gameObject.SetActive(false);
    }
}
*/
/*using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MisionUI : MonoBehaviour
{
    [Header("UI de Misión")]
    public TextMeshProUGUI mensajeTMP;
    public GameObject panelUI; // el panel que contiene el texto y el botón
    public Button botonSiguiente;

    [Header("Mensajes de misión")]
    [TextArea(2, 4)]
    public List<string> mensajes = new List<string>();

    [Header("Cámara")]
    public Transform camaraPrincipal;
    public Vector3 posicionCinematica = new Vector3(0, 5, -5);
    public Vector3 rotacionCinematica = new Vector3(20, 0, 0);

    private Vector3 posicionOriginal;
    private Quaternion rotacionOriginal;

    private int mensajeActual = 0;
    private bool mostrando = false;

    void Start()
    {
        // Ocultar UI al iniciar
        panelUI.SetActive(false);
        botonSiguiente.onClick.AddListener(SiguienteMensaje);
    }

    public void IniciarDialogo()
    {
        if (mostrando) return;

        mostrando = true;
        mensajeActual = 0;

        // Guardar posición y rotación actuales de la cámara
        posicionOriginal = camaraPrincipal.position;
        rotacionOriginal = camaraPrincipal.rotation;

        // Mover la cámara a la posición cinematográfica
        camaraPrincipal.position = posicionCinematica;
        camaraPrincipal.rotation = Quaternion.Euler(rotacionCinematica);

        // Mostrar panel y primer mensaje
        panelUI.SetActive(true);
        mensajeTMP.text = mensajes[mensajeActual];
    }

    public void SiguienteMensaje()
    {
        mensajeActual++;

        if (mensajeActual >= mensajes.Count)
        {
            FinalizarDialogo();
        }
        else
        {
            mensajeTMP.text = mensajes[mensajeActual];
        }
    }

    void FinalizarDialogo()
    {
        // Ocultar el panel
        panelUI.SetActive(false);

        // Volver la cámara a su posición original
        camaraPrincipal.position = posicionOriginal;
        camaraPrincipal.rotation = rotacionOriginal;

        mostrando = false;
    }
}
*/
/*using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MisionUI : MonoBehaviour
{
    [Header("UI de Misión")]
    public TextMeshProUGUI mensajeTMP;
    public GameObject panelUI;

    [Header("Mensajes de misión")]
    [TextArea(2, 4)]
    public List<string> mensajes = new List<string>();
    public float tiempoEntreMensajes = 3f;

    [Header("Cámara")]
    public Transform camaraPrincipal;
    public Vector3 posicionCinematica = new Vector3(0, 5, -5);
    public Vector3 rotacionCinematica = new Vector3(20, 0, 0);

    private Vector3 posicionOriginal;
    private Quaternion rotacionOriginal;

    void Start()
    {
        panelUI.SetActive(false);
        StartCoroutine(MostrarMensajes());
    }

    IEnumerator MostrarMensajes()
    {
        // Guardar posición y rotación originales
        posicionOriginal = camaraPrincipal.position;
        rotacionOriginal = camaraPrincipal.rotation;

        // Mover cámara a vista cinemática
        camaraPrincipal.position = posicionCinematica;
        camaraPrincipal.rotation = Quaternion.Euler(rotacionCinematica);

        // Activar UI
        panelUI.SetActive(true);

        foreach (string mensaje in mensajes)
        {
            mensajeTMP.text = mensaje;
            yield return new WaitForSeconds(tiempoEntreMensajes);
        }

        // Ocultar UI
        panelUI.SetActive(false);

        // Volver cámara a posición original
        camaraPrincipal.position = posicionOriginal;
        camaraPrincipal.rotation = rotacionOriginal;
    }
}
*/
/*using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MisionUI : MonoBehaviour
{
    [Header("UI de Misión")]
    public TextMeshProUGUI mensajeTMP;
    public GameObject panelUI;

    [Header("Mensajes de misión")]
    [TextArea(2, 4)]
    public List<string> mensajes = new List<string>();
    public float tiempoEntreMensajes = 3f;

    void Start()
    {
        panelUI.SetActive(false);
        StartCoroutine(MostrarMensajes());
    }

    IEnumerator MostrarMensajes()
    {
        panelUI.SetActive(true);

        foreach (string mensaje in mensajes)
        {
            mensajeTMP.text = mensaje;
            yield return new WaitForSeconds(tiempoEntreMensajes);
        }

        panelUI.SetActive(false);
    }
}
*/
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MisionUI : MonoBehaviour
{
    [Header("UI de Misión")]
    public TextMeshProUGUI mensajeTMP;
    public GameObject panelUI;

    [Header("Mensajes de misión")]
    [TextArea(2, 4)]
    public List<string> mensajes = new List<string>();
    public float tiempoEntreMensajes = 3f;

    [Header("Objetos a destruir al finalizar")]
    public List<GameObject> objetosADestruir = new List<GameObject>();

    void Start()
    {
        panelUI.SetActive(false);
        StartCoroutine(MostrarMensajes());
    }

    IEnumerator MostrarMensajes()
    {
        panelUI.SetActive(true);

        foreach (string mensaje in mensajes)
        {
            mensajeTMP.text = mensaje;
            yield return new WaitForSeconds(tiempoEntreMensajes);
        }

        panelUI.SetActive(false);

        // 🔥 Destruir objetos al finalizar
        foreach (GameObject obj in objetosADestruir)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
    }
}
