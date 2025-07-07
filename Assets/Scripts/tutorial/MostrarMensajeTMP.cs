using UnityEngine;
using TMPro;

public class MostrarMensajeTMP : MonoBehaviour
{
    public GameObject objetoParaAparecer;  // GameObject que aparecer�
    public TextMeshProUGUI textoTMP;        // Referencia al texto TextMeshPro

    public string mensaje = "�Hola desde TextMeshPro!";

    void Start()
    {
        // Al inicio, oculta el objeto
        objetoParaAparecer.SetActive(false);

        // Mostrar el objeto y el mensaje despu�s de 2 segundos (por ejemplo)
        Invoke("MostrarObjetoYMensaje", 2f);
    }

    void MostrarObjetoYMensaje()
    {
        objetoParaAparecer.SetActive(true);
        textoTMP.text = mensaje;
    }
}
