using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;
    public ParticleSystem glassParticles;

    private AudioSource breakSound;
    private void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            breakSound.Play();
            glassParticles.Play();
            //  AudioManager.instance.GlassBreakPlay();
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            breakSound.Play();
            glassParticles.Play();
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
