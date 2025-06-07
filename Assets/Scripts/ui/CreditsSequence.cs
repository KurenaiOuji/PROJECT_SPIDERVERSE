using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsSequence : MonoBehaviour
{
    public CanvasGroup winPanel;
    public CanvasGroup credits;
    public float fadeDuration = 2f;
    public float intro = 3f;
    public GameObject scrollText;
    public float scrollSpeed = 30f;
    private bool startScrolling = false;

    void Start()
    {
        // Inicia invisible
        winPanel.alpha = 0f;
        credits.alpha = 0f;

        // Desactiva scroll hasta que inicie
        startScrolling = false;
        StartCoroutine(PlayCreditsSequence());
    }

    IEnumerator PlayCreditsSequence()
    {
        //fadein
        yield return StartCoroutine(FadeCanvasGroup(winPanel, 0f, 1f, fadeDuration));
        yield return new WaitForSeconds(intro);

        //fade out
        yield return StartCoroutine(FadeCanvasGroup(winPanel, 1f, 0f, fadeDuration));

        //fade in
        yield return StartCoroutine(FadeCanvasGroup(credits, 0f, 1f, fadeDuration));

        startScrolling = true;
    }

    void Update()
    {
        if (startScrolling && scrollText != null)
        {
            scrollText.transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
        }
    }

    IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float elapsed = 0f;
        cg.alpha = from;
        cg.blocksRaycasts = false;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        cg.alpha = to;
    }
}

