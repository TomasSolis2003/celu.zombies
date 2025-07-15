using UnityEngine;
using TMPro; // Solo si usás TextMeshPro, si no usáslo con UnityEngine.UI

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int puntos = 0;
    public TextMeshProUGUI puntosText; // Asigná en el inspector

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    public bool GastarPuntos(int cantidad)
    {
        if (puntos >= cantidad)
        {
            puntos -= cantidad;
            ActualizarUI();
            return true;
        }
        return false;
    }

    void ActualizarUI()
    {
        if (puntosText != null)
        {
            puntosText.text = "Puntos: " + puntos;
        }
    }
}
