using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [Header("Optional Fade")]
    [SerializeField] private CanvasGroup fadeCanvas;
    [SerializeField] private float fadeDuration = 0.5f;

    private bool isLoading;

    public void StartGame()
    {
        if (isLoading) return;

        isLoading = true;
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        // optional fade out
        if (fadeCanvas != null)
        {
            float t = 0f;

            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                fadeCanvas.alpha = t / fadeDuration;
                yield return null;
            }
        }
        else
        {
            // small fallback delay so click doesn't feel instant
            yield return new WaitForSeconds(0.25f);
        }

        SceneManager.LoadScene("FirstLevel_Apartment");
    }

    public void Quit()
    {
        Application.Quit();
    }
}