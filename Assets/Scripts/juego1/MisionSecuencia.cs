using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MisionSecuencia : MonoBehaviour
{
    [Header("UI de misi�n")]
    public TextMeshProUGUI mensajeTMP;
    public List<string> mensajes = new List<string>();

    [Header("Duraci�n de cada mensaje")]
    public float duracionPorMensaje = 3f;

    [Header("Referencia a la c�mara (opcional)")]
    public Transform camara;

    [Header("Transformaciones opcionales de c�mara durante los mensajes")]
    public List<Vector3> posicionesCamara = new List<Vector3>();

    private Coroutine mostrando;

    void Start()
    {
        // Iniciar secuencia autom�ticamente (opcional)
        IniciarSecuencia();
    }

    public void IniciarSecuencia()
    {
        if (mostrando != null) StopCoroutine(mostrando);
        mostrando = StartCoroutine(MostrarMensajes());
    }

    private IEnumerator MostrarMensajes()
    {
        mensajeTMP.gameObject.SetActive(true);

        for (int i = 0; i < mensajes.Count; i++)
        {
            mensajeTMP.text = mensajes[i];

            // Si hay una posici�n de c�mara asignada para este mensaje
            if (camara != null && i < posicionesCamara.Count)
            {
                camara.position = posicionesCamara[i];
            }

            yield return new WaitForSeconds(duracionPorMensaje);
        }

        mensajeTMP.gameObject.SetActive(false);
        mostrando = null;
    }
}
