using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadePanel : MonoBehaviour
{
    [Header("Fade options")]
    [SerializeField] private float _fadeTime;

    private CanvasGroup _canvasGroup;

    private float _duration = 0.5f;

    private void Start()
    {
        _canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    public void Fade()
    {
        StartCoroutine(DoFade(_canvasGroup, _canvasGroup.alpha, _canvasGroup.alpha == 0 ? 1 : 0));
    }

    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < _duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, counter / _duration);

            if (_canvasGroup.alpha == 0)
            {
                gameObject.SetActive(false);
                _canvasGroup.alpha = 1;
            }

            yield return null;
        }
    }
}