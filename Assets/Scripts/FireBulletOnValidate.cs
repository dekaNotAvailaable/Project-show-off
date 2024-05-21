using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnValidate : MonoBehaviour
{
    public GameObject particleSystemPrefab; // Reference to the particle system prefab
    public Transform firePoint;
    public float fireSpeed = 20;

    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireParticles);
    }
    public void FireParticles(ActivateEventArgs arg)
    {
        GameObject spawnedParticles = Instantiate(particleSystemPrefab);
        spawnedParticles.transform.position = firePoint.position;
        spawnedParticles.transform.rotation = firePoint.rotation;

        ParticleSystem ps = spawnedParticles.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }

        // Optional: Destroy the particle system after it has finished playing
        Destroy(spawnedParticles, ps.main.duration);
    }
}
