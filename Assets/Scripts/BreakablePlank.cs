using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;
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
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }*/
}
