using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    public SpriteRenderer effectsRenderer;
    private Coroutine coroutineId;

    public void StartFade() {
        if (coroutineId != null) {
            StopCoroutine(coroutineId);
        }

        Color startColor = effectsRenderer.color;
        startColor = new Color(startColor.r, startColor.g, startColor.b, 1);

        effectsRenderer.color = startColor;
        coroutineId = StartCoroutine(FadeAlphaToZero(GetComponent<SpriteRenderer>(), 2f));
    }

    IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float duration) {
        Color startColor = effectsRenderer.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0);
        float time = 0;
        while (time < duration) {
            time += Time.deltaTime;
            effectsRenderer.color = Color.Lerp(startColor, endColor, time / duration);
            yield return null;
        }
    }
}
