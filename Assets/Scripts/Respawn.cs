using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField]
    private float RespawnSec;
    Score score;
    private VRWalkIRL VRWalkIRl;
    void Start()
    {
        VRWalkIRl = GetComponent<VRWalkIRL>();
        score = FindAnyObjectByType<Score>();
        if (DieScreen != null)
            DieScreen.enabled = false;
        if (SpawnPoint != null) { Debug.Log("spawnpoint detected"); }
    }
    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(RespawnSec);
        if (DieScreen != null)
        {
            DieScreen.enabled = false;
        }
        if (SpawnPoint != null)
        {
            Debug.Log("spwanpoint postition");
            this.transform.position = SpawnPoint.transform.position;
            if (AudioManager.instance != null)
            {
                AudioManager.instance.RespawnSoundPlay();
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //score.scoreInt--;

            if (AudioManager.instance != null)
            {
                AudioManager.instance.DeathSoundPlay();
            }

            if (DieScreen != null)
            {
                DieScreen.enabled = true;
            }
            StartCoroutine(RespawnAfterDelay());
            Debug.Log("dead");
        }
    }
}
