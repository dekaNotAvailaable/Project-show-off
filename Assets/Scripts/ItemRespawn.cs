using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    private Vector3 initialSpawnPoint;
    private Rigidbody rb;
    private Quaternion initialRotation;
    public GameObject GunSpawnPoint;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (GunSpawnPoint == null)
        {
            initialSpawnPoint = this.transform.position;
            initialRotation = this.transform.rotation;
        }
        else
        {
            GunSpawnPoint.gameObject.transform.position = this.transform.position;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (rb != null)
            {
                this.rb.velocity = Vector3.zero;
            }
            if (GunSpawnPoint == null)
            {
                this.transform.position = initialSpawnPoint;
                this.transform.rotation = initialRotation;
            }
            else
            {
                this.transform.position = GunSpawnPoint.transform.position;
                this.transform.rotation = initialRotation;
            }
        }
    }
}