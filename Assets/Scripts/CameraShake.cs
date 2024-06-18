using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform vrCameraTransform; // Reference to VR camera's transform
    private Coroutine shakeCoroutine;

    void Start()
    {
        // Assuming the VR camera is a child of this GameObject or is set elsewhere
        vrCameraTransform = Camera.main.transform; // Replace with your VR camera's transform
    }

    public IEnumerator Shake(float duration, float strength)
    {
        Vector3 originalPosition = vrCameraTransform.localPosition; // Use VR camera's position
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;
            float z = Random.Range(-1f, 1f) * strength;
            vrCameraTransform.localPosition = originalPosition + new Vector3(x, y, z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        vrCameraTransform.localPosition = originalPosition;
    }

    public void StartShake(float duration, float strength)
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            Debug.Log("Stop shaking");
        }
        Debug.Log("Start shaking");
        shakeCoroutine = StartCoroutine(Shake(duration, strength));
    }

    public void StopShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
            vrCameraTransform.localPosition = Vector3.zero;
        }
    }
}
