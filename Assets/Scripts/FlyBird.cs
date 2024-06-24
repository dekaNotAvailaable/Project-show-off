using System.Collections;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    public float speed = 5f;
    public float sideLength = 10f; // Length of each side of the square
    private Rigidbody rb;
    private AudioSource quackSound;
    private int currentSide = 0;
    private Vector3 startPosition;
    private Vector3[] directions;
    private float traveledDistance = 0f;

    void Start()
    {
        quackSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;

        // Initialize directions for square movement
        directions = new Vector3[]
        {
            Vector3.forward,
            Vector3.right,
            Vector3.back,
            Vector3.left
        };

        startPosition = transform.position;

        // Start the coroutine to play the quack sound randomly
        StartCoroutine(PlayQuackSoundRandomly());
    }

    void Update()
    {
        MoveInSquarePattern();
    }

    private void MoveInSquarePattern()
    {
        Vector3 direction = directions[currentSide];
        Vector3 forwardMovement = direction * speed * Time.deltaTime;
        transform.position += forwardMovement;
        traveledDistance += forwardMovement.magnitude;

        // If the bird has traveled the length of one side of the square, switch to the next side
        if (traveledDistance >= sideLength)
        {
            traveledDistance = 0f;
            currentSide = (currentSide + 1) % 4;
            // Adjust the bird's rotation to face the new direction
            transform.rotation = Quaternion.LookRotation(directions[currentSide], Vector3.up);
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
