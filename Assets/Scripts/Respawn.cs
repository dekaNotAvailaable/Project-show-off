using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField] private float RespawnSec;
    public AudioClip deathSoundClip;
    public AudioClip respawnSoundClip;

    private AudioSource audioSource;
    private Score score;
    private VRWalkIRL VRWalkIRl;

    void Start() {
        VRWalkIRl = GetComponent<VRWalkIRL>();
        score = FindObjectOfType<Score>(); // Changed to FindObjectOfType for simplicity
        audioSource = GetComponent<AudioSource>();

        if (DieScreen != null)
            DieScreen.enabled = false;
        //if (SpawnPoint != null)
            //Debug.Log("Spawnpoint detected");
    }

    private IEnumerator RespawnAfterDelay() {
        yield return new WaitForSeconds(RespawnSec);

        if (DieScreen != null) {
            DieScreen.enabled = false;
        }

        if (SpawnPoint != null) {
            //Debug.Log("Spawnpoint position");
            this.transform.position = SpawnPoint.transform.position;

            if (audioSource != null && respawnSoundClip != null) {
                audioSource.clip = respawnSoundClip;
                audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            score.FallCount--;

            if (audioSource != null && deathSoundClip != null) {
                audioSource.clip = deathSoundClip;
                audioSource.Play();
            }

            if (DieScreen != null) {
                DieScreen.enabled = true;
            }

            StartCoroutine(RespawnAfterDelay());
            //Debug.Log("Dead");
        }
    }
}
