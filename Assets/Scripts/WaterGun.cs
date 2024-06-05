using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterGun : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField]
    private float maxDistance = 10f;
    [SerializeField]
    private float waterForce = 10f;
    [SerializeField]
    private float lineStartWidth = 0.1f;
    [SerializeField]
    private float lineEndWidth = 0.1f;
    private LineRenderer lineRenderer;
    private XRGrabInteractable grabbable;

    private void Start()
    {
        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(ShootWater);
        grabbable.deactivated.AddListener(StopShooting);
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = lineStartWidth;
        lineRenderer.endWidth = lineEndWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.enabled = false;
    }

    private void ShootWater(ActivateEventArgs arg)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, maxDistance))
        {
            lineRenderer.SetPosition(1, hit.point);
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForceAtPosition(firePoint.forward * waterForce, hit.point);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * maxDistance);
        }
    }

    private void StopShooting(DeactivateEventArgs arg)
    {
        lineRenderer.enabled = false;
    }
}
