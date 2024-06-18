using System.Collections;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 2f;
    public float frequency = 0.3f;
    private Rigidbody rb;
    private Vector3 startPosition;
    private AudioSource quackSound;

    void Start()
    {
        quackSound = GetComponent<AudioSource>();
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;

        // Start the coroutine to play the quack sound randomly
        StartCoroutine(PlayQuackSoundRandomly());
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

    private IEnumerator PlayQuackSoundRandomly()
    {
        while (true)
        {
            // Wait for a random time between 2 and 10 seconds
            float waitTime = Random.Range(2f, 10f);
            yield return new WaitForSeconds(waitTime);

            // Play the quack sound if it is not null
            if (quackSound != null)
            {
                quackSound.Play();
            }
        }
    }
}
