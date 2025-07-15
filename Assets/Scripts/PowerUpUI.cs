
using UnityEngine;
using TMPro;
using System.Collections;

public class PowerUpUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public void ShowPowerUpMessage(string message, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessageCoroutine(message, duration));
    }

    private IEnumerator ShowMessageCoroutine(string message, float duration)
    {
        messageText.gameObject.SetActive(true);

        float timeLeft = duration;
        while (timeLeft > 0)
        {
            messageText.text = $"{message}\n{timeLeft:F1}s";
            yield return new WaitForSeconds(0.1f);
            timeLeft -= 0.1f;
        }

        messageText.gameObject.SetActive(false);
    }
}
