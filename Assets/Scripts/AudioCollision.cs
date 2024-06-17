using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public float magnitude = 20.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitude)
        {
            GetComponent<AudioSource>().Play();
        }

        Debug.Log(collision.collider.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the current GameObject has a specific tag (e.g., "GlassPlank")
        if (gameObject.CompareTag("GlassPlank"))
        {
            // Check if the other collider is tagged as "Player"
            if (other.CompareTag("Player"))
            {
                // Play random footstep sound
                int random = Random.Range(0, 3);
                if (random == 0)
                {
                    AudioManager.instance.GlassFoot1Play();
                }
                else if (random == 1)
                {
                    AudioManager.instance.GlassFoot2Play();
                }
                else
                {
                    AudioManager.instance.GlassFoot3Play();
                }
            }
        }
    }
}
