using UnityEngine;

public class AudioCollision : MonoBehaviour
{

    public float magnitude = 20.0f;
    void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > magnitude)
        {

            if (collision.relativeVelocity.magnitude > 20)

                GetComponent<AudioSource>().Play();

            Debug.Log(collision.collider.name);
        }
    }
}