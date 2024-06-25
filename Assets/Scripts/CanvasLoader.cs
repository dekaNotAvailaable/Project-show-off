using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CanvasLoader : MonoBehaviour
{
    public GameObject EndMenu;
    public GameObject player;
    public Transform head;
    public Animator animator;//elia
    private Score score;
    private void Start()
    {
        score = FindAnyObjectByType<Score>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        //Temporarily disable animation
        if (animator != null)
        {
            animator.enabled = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            score.ScoreUpdate();
            EndMenu.SetActive(true);
            AudioSource audioSource = EndMenu.GetComponent<AudioSource>();
            if (audioSource != null) {
                audioSource.Play();

            } else {
                Debug.Log("AudioSource component not found on EndMenu GameObject.");
            }
            
            player.GetComponent<ContinuousMoveProviderBase>().enabled = false;
            player.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            Vector3 forwardDirection = new Vector3(head.forward.x, 0, head.forward.z).normalized;
            EndMenu.transform.position = head.position + forwardDirection * 2;
            EndMenu.transform.LookAt(new Vector3(head.position.x, EndMenu.transform.position.y, head.position.z));
            EndMenu.transform.forward *= -1;
        }

        //Rehabilitates animation
        if (animator != null)
        {
            animator.enabled = true;
        }
    }
}