using UnityEngine;

public class BreakablePlank : MonoBehaviour
{
    [SerializeField]
    private float breakSec = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("break");
            Destroy(gameObject, breakSec);
            Debug.Log("Breaking Plank");
        }
    }
}
