using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField]
    private float RespawnSec;
    void Start() {
        if (DieScreen != null)
            DieScreen.enabled = false;
        if (SpawnPoint != null) { Debug.Log("spawnpoint detected"); }
    }
    private IEnumerator RespawnAfterDelay() {
        yield return new WaitForSeconds(RespawnSec);
        if (DieScreen != null) {
            DieScreen.enabled = false;
        }
        if (SpawnPoint != null) 
        {
            Debug.Log("spwanpoint postition");
            this.transform.position = SpawnPoint.transform.position;
        }
    }
<<<<<<< HEAD
    private void OnTriggerEnter(Collider collision) {
=======
    private void OnCollisionEnter(Collision collision) {
>>>>>>> parent of e1dd342 (okkkk)
        if (collision.gameObject.CompareTag("Ground")) {
            if (DieScreen != null) {
                DieScreen.enabled = true;
            }
            StartCoroutine(RespawnAfterDelay());
            
            Debug.Log("dead");
        }
    }
}
