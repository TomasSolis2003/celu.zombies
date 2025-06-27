using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego"); // Reemplazá con el nombre real de tu escena
    }

    public void CargarTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CargarModoInfinito()
    {
        SceneManager.LoadScene("ModoInfinito");
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
