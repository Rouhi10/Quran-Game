using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image ProgressImage;

    public float TimeToFill = 5f;

    public UnityEvent OnFillComplete;
    private void OnEnable()
    {
        Debug.Log("Start");
        StartCoroutine(FillImageOverTime(TimeToFill));
    }

    IEnumerator FillImageOverTime(float duration)
    {
        if (ProgressImage == null)
        {
            Debug.LogError("ProgressImage is not assigned.");
            yield break;
        }

        ProgressImage.fillAmount = 0f;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            ProgressImage.fillAmount = Mathf.Clamp01(timer / duration);

            yield return null;
        }

        ProgressImage.fillAmount = 1f;

        OnFillComplete?.Invoke();
    }


}
