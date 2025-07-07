/*using UnityEngine;
using System.Collections.Generic;

public class ActivadorDeObjetos : MonoBehaviour
{
    [Header("Objetos a activar")]
    public List<GameObject> objetosParaActivar = new List<GameObject>();

    [Header("Activar al iniciar")]
    public bool activarAlIniciar = false;

    void Start()
    {
        if (activarAlIniciar)
        {
            ActivarObjetos();
        }
    }

    public void ActivarObjetos()
    {
        foreach (GameObject obj in objetosParaActivar)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
*/
/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivadorProgresivo : MonoBehaviour
{
    [Header("Objetos a activar progresivamente")]
    public List<GameObject> objetosParaActivar = new List<GameObject>();

    [Header("Tiempo entre cada activación")]
    public float tiempoEntreActivaciones = 2f;

    [Header("Iniciar automáticamente")]
    public bool iniciarAlComenzar = true;

    private void Start()
    {
        if (iniciarAlComenzar)
        {
            StartCoroutine(ActivarObjetosUnoPorUno());
        }
    }

    public void IniciarActivacionManual()
    {
        StartCoroutine(ActivarObjetosUnoPorUno());
    }

    private IEnumerator ActivarObjetosUnoPorUno()
    {
        foreach (GameObject obj in objetosParaActivar)
        {
            if (obj != null)
                obj.SetActive(true);

            yield return new WaitForSeconds(tiempoEntreActivaciones);
        }
    }
}
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivadorProgresivo : MonoBehaviour
{
    [Header("Objetos a activar progresivamente")]
    public List<GameObject> objetosParaActivar = new List<GameObject>();

    [Header("Tiempos")]
    public float tiempoInicialDeEspera = 5f;
    public float tiempoEntreActivaciones = 2f;

    [Header("Iniciar automáticamente")]
    public bool iniciarAlComenzar = true;

    private void Start()
    {
        // Asegurarse de que estén todos desactivados al comenzar
        foreach (GameObject obj in objetosParaActivar)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        if (iniciarAlComenzar)
        {
            StartCoroutine(ActivarObjetosConEsperaInicial());
        }
    }

    public void IniciarActivacionManual()
    {
        StartCoroutine(ActivarObjetosConEsperaInicial());
    }

    private IEnumerator ActivarObjetosConEsperaInicial()
    {
        // Espera inicial antes de activar cualquier cosa
        yield return new WaitForSeconds(tiempoInicialDeEspera);

        // Activar objetos uno por uno con delay
        foreach (GameObject obj in objetosParaActivar)
        {
            if (obj != null)
                obj.SetActive(true);

            yield return new WaitForSeconds(tiempoEntreActivaciones);
        }
    }
}
