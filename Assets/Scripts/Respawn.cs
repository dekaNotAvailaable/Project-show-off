using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField]
    private float RespawnSec;
    void Start()
    {
        if (DieScreen != null)
            DieScreen.enabled = false;
    }
    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(RespawnSec);
        if (DieScreen != null)
        {
            DieScreen.enabled = false;
        }
        if (SpawnPoint != null)
            this.transform.position = SpawnPoint.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DieScreen.enabled = true;
            RespawnAfterDelay();
            Debug.Log("dead");
        }
    }
}
