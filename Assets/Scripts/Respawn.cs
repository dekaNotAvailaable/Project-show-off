using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public Image DieScreen;
    [SerializeField] private float RespawnSec;
    public AudioSource deathSoundSource;
    public AudioClip deathSoundClip;
    public AudioClip respawnSoundClip;
    private Rigidbody rb;
    private AudioSource audioSource;
    private Score score;
    private VRWalkIRL VRWalkIRl;

    void Start()
    {
        VRWalkIRl = GetComponent<VRWalkIRL>();
        score = FindObjectOfType<Score>(); // Changed to FindObjectOfType for simplicity

        deathSoundSource = GetComponent<AudioSource>();

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

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


        if (SpawnPoint != null)
        {
            //Debug.Log("Spawnpoint position");
            this.transform.position = SpawnPoint.transform.position;


            if (SpawnPoint != null)
            {
                Debug.Log("Spawnpoint position");
                this.transform.position = SpawnPoint.transform.position;

                if (audioSource != null && respawnSoundClip != null)
                {
                    audioSource.clip = respawnSoundClip;
                    audioSource.Play();
                }

            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            score.FallCount--;


            deathSoundSource.Play();
            if (audioSource != null && deathSoundClip != null)
            {
                audioSource.clip = deathSoundClip;
                audioSource.Play();
            }

            if (DieScreen != null)
            {
                DieScreen.enabled = true;
            }

            StartCoroutine(RespawnAfterDelay());
            //Debug.Log("Dead");
        }
        if (collision.gameObject.CompareTag("CheckSpawn"))
        {
            GameObject checkSpawnObject = GameObject.FindGameObjectWithTag("CheckSpawn");
            SpawnPoint.transform.position = checkSpawnObject.transform.position;
        }
    }
}

