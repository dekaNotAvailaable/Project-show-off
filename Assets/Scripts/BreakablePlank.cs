using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;

    private AudioSource breakSound;
    public GameObject glassParticlesPrefab;
  //  public ParticleSystem breakParticle;
    private void Start()
    {
        breakSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            breakSound.Play();
          //  breakParticle.gameObject.transform.parent = null;
        //    breakParticle.Play();
            Instantiate(glassParticlesPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject, breakSec);
            //  AudioManager.instance.GlassBreakPlay();

            Debug.Log("Breaking Plank");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            breakSound.Play();
            Instantiate(glassParticlesPrefab, transform.position, Quaternion.identity);
         //   breakParticle.Play();
            //breakParticle.gameObject.transform.parent = null;
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
