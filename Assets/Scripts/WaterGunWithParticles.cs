using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterGunWithParticles : MonoBehaviour
{
    public Transform firePoint;
    public ParticleSystem waterParticles;
    [SerializeField]
    private float LifeTime = 10f;
    [SerializeField]
    private float StartSpeed = 10f;
    private XRGrabInteractable grabbable;
    private Vector3 lastFirePointPosition;


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
        main.startSpeed = StartSpeed;
        main.startLifetime = LifeTime;
        waterParticles.Stop();
    }

    private void Update()
    {
        if (firePoint.position != lastFirePointPosition)
        {
            UpdateParticleSystemPosition();
            lastFirePointPosition = firePoint.position;
        }
    }

    private void ShootWater(ActivateEventArgs arg)
    {
        waterParticles.Play();
        UpdateParticleSystemPosition();
    }

    private void UpdateParticleSystemPosition()
    {
        waterParticles.transform.position = firePoint.position;
        waterParticles.transform.rotation = firePoint.rotation;

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, LifeTime))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(firePoint.forward * 0f, hit.point);
            }
        }
    }

    private void StopShooting(DeactivateEventArgs arg)
    {
        waterParticles.Stop();
    }
}