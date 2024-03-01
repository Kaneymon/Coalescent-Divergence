using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    Transform cameraTransform;
    
    Vector3 initialPosition;
    [SerializeField]
    float shakeMagnitude = 1;
    [SerializeField]
    float dampingSpeed = 1;
    [SerializeField]
    float shakeDuration = 1;
    private void Start()
    {
        cameraTransform = this.gameObject.transform;
        initialPosition = cameraTransform.localPosition;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float duration)
    {
        shakeDuration = duration;
    }
}
