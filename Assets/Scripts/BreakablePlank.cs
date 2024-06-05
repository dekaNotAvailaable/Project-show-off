using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;

    [SerializeField] AudioSource myAudio;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
            myAudio.Play(0);
        }
    }
}
