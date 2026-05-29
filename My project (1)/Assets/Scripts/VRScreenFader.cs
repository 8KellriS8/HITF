using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class VRScreenFader : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private Coroutine currentFadeRoutine;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Метод для вызова затемнения (в черный экран)
    public void FadeOut(float duration)
    {
        StartFade(1f, duration);
    }

    // Метод для вызова просветления (в прозрачный экран)
    public void FadeIn(float duration)
    {
        StartFade(0f, duration);
    }

    private void StartFade(float targetAlpha, float duration)
    {
        if (currentFadeRoutine != null)
            StopCoroutine(currentFadeRoutine);

        currentFadeRoutine = StartCoroutine(FadeRoutine(targetAlpha, duration));
    }

    private IEnumerator FadeRoutine(float targetAlpha, float duration)
    {
        float startAlpha = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }
}