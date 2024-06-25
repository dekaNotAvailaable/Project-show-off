using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;

    private AudioSource breakSound;

    public ParticleSystem breakParticle;
    private void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            breakSound.Play();
            breakParticle.Play();
            Destroy(gameObject, breakSec);
            //  AudioManager.instance.GlassBreakPlay();

            Debug.Log("Breaking Plank");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            breakParticle.Play();
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
