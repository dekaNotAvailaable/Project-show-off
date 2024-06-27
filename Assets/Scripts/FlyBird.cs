using System.Collections;
using UnityEngine;

public class FlyBird : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float circleRadius = 10f;
    [SerializeField]
    private float verticalAmplitude = 2f;
    [SerializeField]
    private float verticalFrequency = 1f;

    private Rigidbody rb;
    private AudioSource quackSound;
    private float angle = 0f;
    private Vector3 startPosition;
    private ParticleSystem feathers;

    private void Start()
    {
        quackSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX;
        feathers = GetComponent<ParticleSystem>();
        startPosition = transform.position;
        StartCoroutine(PlayQuackSoundRandomly());
    }

    private void Update()
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
        Vector3 direction = new Vector3(-Mathf.Sin(angle), 0, Mathf.Cos(angle));
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (feathers != null)
        {
            feathers.Play();
        }
    }

    private IEnumerator PlayQuackSoundRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(2f, 10f);
            yield return new WaitForSeconds(waitTime);
            if (quackSound != null)
            {
                quackSound.Play();
            }
        }
    }
}
