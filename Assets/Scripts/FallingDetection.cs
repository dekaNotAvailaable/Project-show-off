using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FallingDetection : MonoBehaviour
{
    public Rigidbody rb;
    public CameraShake cameraShake;
    public Volume postProcessVolume;
    [Header("Post processing tweak")]
    [SerializeField]
    private float shakeIncreaseRate = 0.5f;
    [SerializeField]
    private float intensityIncreaseRate;
    [SerializeField]
    private float maxShakeIntensity = 5.0f;
    [SerializeField]
    private float shakeDuration = 0.1f;
    [SerializeField]
    private float fallThreshold = -0.1f;
    private float intensityValue = 0.0f;
    private float shakeStrength = 0.0f;
    private bool isFalling = false;
    private Vector3 previousPosition;
    private Vignette vignette;
    private ChromaticAberration chromaticAberration;

    void Start()
    {
        previousPosition = rb.position;
        if (postProcessVolume != null)
        {
            postProcessVolume.profile.TryGet<Vignette>(out vignette);
            postProcessVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        }
        else { Debug.Log("postprocessingvolume is null "); }
    }

    void Update()
    {
        Vector3 currentPosition = rb.position;
        float yVelocity = (currentPosition.y - previousPosition.y);

        if (yVelocity < fallThreshold)
        {
            if (!isFalling)
            {
                isFalling = true;
                shakeStrength = 0.0f;
                intensityValue = 0.0f;
            }
            intensityValue += intensityIncreaseRate * Time.deltaTime;
            intensityValue = Mathf.Clamp(intensityValue, 0, 1f);
            shakeStrength += shakeIncreaseRate * Time.deltaTime;
            shakeStrength = Mathf.Clamp(shakeStrength, 0.0f, maxShakeIntensity);
            cameraShake.StartShake(shakeDuration, shakeStrength);
            if (vignette != null)
            {
                vignette.intensity.value = intensityValue;
                Debug.Log("viggnete tweaking:" + vignette.intensity.value);

            }
            if (chromaticAberration != null)
            {
                chromaticAberration.intensity.value = intensityValue;
                Debug.Log("chiromistcabertion tweaking:" + chromaticAberration.intensity.value);
            }
        }
        else
        {
            if (isFalling)
            {
                isFalling = false;
                cameraShake.StopShake();

                // Reset post-processing effects
                if (vignette != null)
                {
                    vignette.intensity.value = 0.0f;
                }

                if (chromaticAberration != null)
                {
                    chromaticAberration.intensity.value = 0.0f;
                }
            }
        }

        previousPosition = currentPosition;
    }
}
