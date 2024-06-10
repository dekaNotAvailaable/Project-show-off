using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterGunWithParticles : MonoBehaviour
{
    public Transform firePoint;
    public ParticleSystem waterParticles;
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    private float waterForce = 10f;
    private XRGrabInteractable grabbable;
    private Vector3 lastFirePointPosition;
    private bool isAlreadyShot;

    private void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(ShootWater);
        grabbable.deactivated.AddListener(StopShooting);

        if (waterParticles == null)
        {
            Debug.LogError("No Particle System assigned to the Water Gun.");
            return;
        }

        var main = waterParticles.main;
        main.startSpeed = maxDistance;  // Adjust this value to control the distance
        main.startLifetime = maxDistance / main.startSpeed.constant; // Calculate the lifetime based on speed and distance
        waterParticles.Stop();
    }

    private void Update()
    {
        if (firePoint.position != lastFirePointPosition && !isAlreadyShot)
        {
            UpdateParticleSystemPosition();
            lastFirePointPosition = firePoint.position;
        }
    }

    private void ShootWater(ActivateEventArgs arg)
    {
        waterParticles.Play();
        UpdateParticleSystemPosition();
        isAlreadyShot = true;
    }

    private void UpdateParticleSystemPosition()
    {
        waterParticles.transform.position = firePoint.position;
        waterParticles.transform.rotation = firePoint.rotation;

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxDistance))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(firePoint.forward * waterForce, hit.point);
            }
        }
    }

    private void StopShooting(DeactivateEventArgs arg)
    {
        waterParticles.Stop();
    }
}
