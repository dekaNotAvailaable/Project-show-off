using System.Collections;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 5f;
    public float circleRadius = 10f; // Radius of the circular movement
    public float verticalAmplitude = 2f; // Amplitude of the vertical oscillation
    public float verticalFrequency = 1f; // Frequency of the vertical oscillation

    private Rigidbody rb;
    private AudioSource quackSound;
    private float angle = 0f; // Angle for the circular movement
    private Vector3 startPosition;

    void Start()
    {
        quackSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;

        startPosition = transform.position;

        // Start the coroutine to play the quack sound randomly
        StartCoroutine(PlayQuackSoundRandomly());
    }

    void Update()
    {
        MoveInDynamicPattern();
    }

    private void MoveInDynamicPattern()
    {
        float x = circleRadius * Mathf.Cos(angle);
        float z = circleRadius * Mathf.Sin(angle);
        float y = verticalAmplitude * Mathf.Sin(verticalFrequency * angle);
        transform.position = startPosition + new Vector3(x, y, z);
        angle += speed * Time.deltaTime;

        // Ensure the bird is always facing forward along the circular path
        Vector3 direction = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
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
