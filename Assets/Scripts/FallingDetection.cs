using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FallingDetection : MonoBehaviour {
    public Rigidbody rb;
    public CinemachineImpulseSource impulseSource;
    public Volume postProcessVolume;
    public AudioSource fallingAudioSource;  // Add this line

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
    [SerializeField] private float fadeDuration = 1.0f;
    private float currentFadeTime = 0.0f;
    private float targetVolume = 0.0f;
    private float initialVolume = 0.0f;
    void Start() {
        previousPosition = rb.position;
        if (postProcessVolume != null) {
            postProcessVolume.profile.TryGet<Vignette>(out vignette);
            postProcessVolume.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        } else {
            Debug.Log("postprocessingvolume is null");
        }

        if (fallingAudioSource == null) {
            Debug.LogWarning("fallingAudioSource is not assigned");
        }
    }

    void Update() {
        Vector3 currentPosition = rb.position;
        float yVelocity = (currentPosition.y - previousPosition.y);

        if (yVelocity < fallThreshold) {
            if (!isFalling) {
                isFalling = true;
                shakeStrength = 0.0f;
                intensityValue = 0.0f;
                initialVolume = fallingAudioSource.volume; // Store initial volume
                targetVolume = 1.0f; // Target volume for fade-in
                currentFadeTime = 0.0f; // Reset fade time
                if (fallingAudioSource != null && !fallingAudioSource.isPlaying) {
                    fallingAudioSource.Play();  // Play falling sound
                }
            }
            intensityValue += intensityIncreaseRate * Time.deltaTime;
            intensityValue = Mathf.Clamp(intensityValue, 0, 1f);
            shakeStrength += shakeIncreaseRate * Time.deltaTime;
            shakeStrength = Mathf.Clamp(shakeStrength, 0.0f, maxShakeIntensity);
            if (impulseSource != null) {
                Vector3 impulseDirection = new Vector3(0, -1, 0);
                float forceMagnitude = shakeStrength;
                impulseSource.GenerateImpulse(impulseDirection * forceMagnitude);
            }

            if (vignette != null) {
                vignette.intensity.value = intensityValue;
                // Debug.Log("vignette tweaking:" + vignette.intensity.value);
            }
            if (chromaticAberration != null) {
                chromaticAberration.intensity.value = intensityValue;
                // Debug.Log("chromatic aberration tweaking:" + chromaticAberration.intensity.value);
            }
        } else {
            if (isFalling) {
                isFalling = false;
                targetVolume = 0.0f; // Target volume for fade-out
                initialVolume = fallingAudioSource.volume; // Store initial volume
                currentFadeTime = 0.0f; // Reset fade time
                if (fallingAudioSource != null && fallingAudioSource.isPlaying) {
                    fallingAudioSource.Stop();  // Stop falling sound
                }

                if (vignette != null) {
                    vignette.intensity.value = 0.0f;
                }

                if (chromaticAberration != null) {
                    chromaticAberration.intensity.value = 0.0f;
                }
            }
        }

        if (currentFadeTime < fadeDuration) {
            currentFadeTime += Time.deltaTime;
            float t = currentFadeTime / fadeDuration;
            fallingAudioSource.volume = Mathf.Lerp(initialVolume, targetVolume, t);
        } else if (!isFalling && fallingAudioSource.volume > 0) {
            fallingAudioSource.Stop(); // Ensure audio stops when volume reaches zero
        }

        previousPosition = currentPosition;
    }
}
