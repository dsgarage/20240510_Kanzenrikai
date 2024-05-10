using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimelineFadeTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));  // 不透明から透明へ
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));  // 透明から不透明へ
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, newAlpha);
            yield return null;  // 次のフレームまで待機
        }
    }
}