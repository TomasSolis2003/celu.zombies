/*using UnityEngine;
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
*/
/*using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [Header("UI de Fin de Partida")]
    public GameObject panelFinDePartida;

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

    public void VolverAlMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambiá por el nombre real del menú
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void FinalizarPartida()
    {
        if (panelFinDePartida != null)
            panelFinDePartida.SetActive(true);

        // Pausar el tiempo si querés detener el juego
        Time.timeScale = 0f;
    }
}
*/
/*using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Manager : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelFinDePartida;
    public GameObject panelOpciones;

    private bool juegoPausado = false;

    void Update()
    {
        // Presionar Escape para abrir/cerrar opciones
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleOpciones();
        }
    }

    public void CargarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Juego");
    }

    public void CargarTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }

    public void CargarModoInfinito()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ModoInfinito");
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Usás este nombre exacto
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Detiene la ejecución en el editor
#endif
    }

    public void FinalizarPartida()
    {
        if (panelFinDePartida != null)
            panelFinDePartida.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ToggleOpciones()
    {
        if (panelOpciones == null) return;

        juegoPausado = !juegoPausado;
        panelOpciones.SetActive(juegoPausado);
        Time.timeScale = juegoPausado ? 0f : 1f;
    }

    public void ReanudarJuego()
    {
        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        juegoPausado = false;
        Time.timeScale = 1f;
    }
}
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [Header("UI")]
    public GameObject panelFinDePartida;
    public GameObject panelOpciones;

    private bool juegoPausado = false;

    // Se puede eliminar Update() si no usás teclas para abrir opciones
    // void Update() {}

    public void CargarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Juego");
    }

    public void CargarTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }

    public void CargarModoInfinito()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ModoInfinito");
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void FinalizarPartida()
    {
        if (panelFinDePartida != null)
            panelFinDePartida.SetActive(true);

        Time.timeScale = 0f;
    }

    // 👇 Este lo vas a asignar al botón "Opciones"
    public void AbrirOpciones()
    {
        if (panelOpciones != null)
        {
            panelOpciones.SetActive(true);
            Time.timeScale = 0f;
            juegoPausado = true;
        }
    }

    public void ReanudarJuego()
    {
        if (panelOpciones != null)
            panelOpciones.SetActive(false);

        juegoPausado = false;
        Time.timeScale = 1f;
    }
}
