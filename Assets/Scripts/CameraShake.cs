using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Coroutine shakeCoroutine;

    public IEnumerator Shake(float duration, float strength)
    {
        Vector3 originalPosition = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * strength;
            float y = Random.Range(-1f, 1f) * strength;
            float z = Random.Range(-1f, 1f) * strength;
            transform.localPosition = originalPosition + new Vector3(x, y, z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = originalPosition;
    }

    public void StartShake(float duration, float strength)
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            Debug.Log("stop shaking");
        }
        Debug.Log("start shaking");
        shakeCoroutine = StartCoroutine(Shake(duration, strength));
    }

    public void StopShake()
    {
        if (shakeCoroutine != null)
        {
            StopCoroutine(shakeCoroutine);
            shakeCoroutine = null;
            transform.localPosition = Vector3.zero;
        }
    }
}
