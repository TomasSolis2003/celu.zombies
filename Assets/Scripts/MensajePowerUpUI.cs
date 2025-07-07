using UnityEngine;
using TMPro;
using System.Collections;

public class MensajePowerUpUI : MonoBehaviour
{
    public TextMeshProUGUI mensajeTMP;

    public void MostrarContador(string textoBase, float segundos)
    {
        StartCoroutine(ContadorCoroutine(textoBase, segundos));
    }

    IEnumerator ContadorCoroutine(string textoBase, float segundos)
    {
        mensajeTMP.gameObject.SetActive(true);

        for (int i = (int)segundos; i > 0; i--)
        {
            mensajeTMP.text = $"{textoBase}: {i}";
            yield return new WaitForSeconds(1f);
        }

        mensajeTMP.text = "⚠️ Efecto finalizado";
        yield return new WaitForSeconds(2f);

        mensajeTMP.gameObject.SetActive(false);
    }
}
