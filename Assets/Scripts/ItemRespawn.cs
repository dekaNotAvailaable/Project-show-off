using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    private Vector3 initialSpawnPoint;
    private Rigidbody rb;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialSpawnPoint = this.transform.position;
        initialRotation = this.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.transform.position = initialSpawnPoint;
            this.transform.rotation = initialRotation;
            if (rb != null)
            {
                this.rb.velocity = Vector3.zero;
            }
        }
    }
}
