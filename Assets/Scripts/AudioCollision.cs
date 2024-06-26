using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    public float magnitude = 20.0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitude)
        {
            //if(AudioSource != null)
            //<AudioSource>().Play();
            AudioSource source= GetComponent<AudioSource>();

            if (source!=null)
                source.Play();

        }

        //Debug.Log(collision.collider.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the current GameObject has a specific tag (e.g., "GlassPlank")
        //if (gameObject.CompareTag("GlassPlank"))
        //{
        //// Check if the other collider is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Play random footstep sound
            int random = Random.Range(0, 3);
            if (random == 0)
            {
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.GlassFoot1Play();
                }
            }
            else if (random == 1)
            {
                if (AudioManager.instance != null)
                    AudioManager.instance.GlassFoot2Play();
            }
            else
            {
                if (AudioManager.instance != null)
                    AudioManager.instance.GlassFoot3Play();
            }
        }

    }
}
