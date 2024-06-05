using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    private Vector3 initialSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        initialSpawnPoint = this.transform.position;
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
            this.transform.rotation = Quaternion.identity;
        }
    }
}
