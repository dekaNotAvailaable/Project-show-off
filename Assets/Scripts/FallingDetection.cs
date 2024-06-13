using UnityEngine;

public class FallingDetection : MonoBehaviour
{
    public Rigidbody rb;
    public CameraShake cameraShake;
    public float shakeIncreaseRate = 0.5f;
    public float maxShakeIntensity = 5.0f;
    public float shakeDuration = 0.1f;
    public float fallThreshold = -0.1f;

    private float shakeStrength = 0.0f;
    private bool isFalling = false;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = rb.position;
    }

    void Update()
    {
        Vector3 currentPosition = rb.position;
        float yVelocity = (currentPosition.y - previousPosition.y) / Time.deltaTime;
        // Debug.Log(yVelocity);
        if (yVelocity < fallThreshold)
        {
            if (!isFalling)
            {
                isFalling = true;
                shakeStrength = 0.0f;
            }

            shakeStrength += shakeIncreaseRate * Time.deltaTime;
            shakeStrength = Mathf.Clamp(shakeStrength, 0.0f, maxShakeIntensity);
            cameraShake.StartShake(shakeDuration, shakeStrength);
        }
        else
        {
            if (isFalling)
            {
                isFalling = false;
                cameraShake.StopShake();
            }
        }

        previousPosition = currentPosition;
    }
}
