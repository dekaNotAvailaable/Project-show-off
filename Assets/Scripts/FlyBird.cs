using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 2f;
    public float frequency = 0.3f;
    private Rigidbody rb;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
    }
    void Update()
    {
        Vector3 forwardMovement = transform.forward * speed * Time.deltaTime;
        float wave = Mathf.Sin(Time.time * frequency) * amplitude;
        Vector3 newPosition = transform.position + forwardMovement;
        newPosition.y = startPosition.y + wave;
        transform.position = newPosition;
        Vector3 lookDirection = forwardMovement;
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }
}
