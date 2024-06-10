using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;
<<<<<<< HEAD
    private void OnTriggerEnter(Collider collision)
=======

    [SerializeField] AudioSource myAudio;
    
    private void OnCollisionEnter(Collision collision)
>>>>>>> Sound-Design
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
            myAudio.Play(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
