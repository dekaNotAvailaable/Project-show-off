using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField] private float RespawnSec;
<<<<<<< Updated upstream
    public AudioSource deathSoundSource;
=======
    public AudioClip deathSoundClip;
    public AudioClip respawnSoundClip;
    private Rigidbody rb;
    private AudioSource audioSource;
>>>>>>> Stashed changes
    private Score score;
    private VRWalkIRL VRWalkIRl;

    void Start()
    {
        VRWalkIRl = GetComponent<VRWalkIRL>();
        score = FindObjectOfType<Score>(); // Changed to FindObjectOfType for simplicity
<<<<<<< Updated upstream
        deathSoundSource = GetComponent<AudioSource>();

=======
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
>>>>>>> Stashed changes
        if (DieScreen != null)
            DieScreen.enabled = false;
        //if (SpawnPoint != null)
            //Debug.Log("Spawnpoint detected");
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(RespawnSec);

        if (DieScreen != null)
        {
            DieScreen.enabled = false;
        }

<<<<<<< Updated upstream
        if (SpawnPoint != null) {
            //Debug.Log("Spawnpoint position");
            this.transform.position = SpawnPoint.transform.position;


=======
        if (SpawnPoint != null)
        {
            Debug.Log("Spawnpoint position");
            this.transform.position = SpawnPoint.transform.position;

            if (audioSource != null && respawnSoundClip != null)
            {
                audioSource.clip = respawnSoundClip;
                audioSource.Play();
            }
>>>>>>> Stashed changes
        }
    }
    private void Update()
    {
        if (rb.transform.position.z >= -14)
        {
            SpawnPoint.transform.position = new Vector3(-1.25519562f, 29.3341007f, -14.5645199f);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            score.FallCount--;

<<<<<<< Updated upstream

            deathSoundSource.Play();
            
=======
            if (audioSource != null && deathSoundClip != null)
            {
                audioSource.clip = deathSoundClip;
                audioSource.Play();
            }
>>>>>>> Stashed changes

            if (DieScreen != null)
            {
                DieScreen.enabled = true;
            }

            StartCoroutine(RespawnAfterDelay());
            //Debug.Log("Dead");
        }
    }
}
