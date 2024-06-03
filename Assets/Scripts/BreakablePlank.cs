using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
        if (collision.gameObject.CompareTag("Marble"))
        {
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
