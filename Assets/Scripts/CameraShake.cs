using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Shake Setting")]
    [SerializeField] private float shakeDuration = 0.5f; // مدت زمان لرزش
    [SerializeField] private float shakeMagnitude = 0.1f; // شدت لرزش

    private Vector3 initialPosition; // موقعیت اولیه دوربین
    private float currentShakeDuration;
    private bool isShaking = false;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (isShaking)
        {
            if (currentShakeDuration > 0)
            {
                // ایجاد حرکت لرزشی تصادفی
                transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

                currentShakeDuration -= Time.deltaTime;
            }
            else
            {
                // پایان لرزش و بازگشت به موقعیت اولیه
                isShaking = false;
                transform.localPosition = initialPosition;
            }
        }
    }

    // تابع  برای فعال کردن لرزش
    public void TriggerShake()
    {
        currentShakeDuration = shakeDuration;
        isShaking = true;
    }

}
