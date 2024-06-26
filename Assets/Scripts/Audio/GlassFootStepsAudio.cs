using UnityEngine;

public class GlassFootStepsAudio : MonoBehaviour
{
    private AudioSource[] glassFootSteps;
    private void Start()
    {
        glassFootSteps = GetComponents<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayRandomAudio();
        }
    }
    private void PlayRandomAudio()
    {
        if (glassFootSteps.Length == 0)
        {
            //Debug.LogWarning("No AudioSources found!");
            return;
        }
        int randomIndex = Random.Range(0, glassFootSteps.Length);
        glassFootSteps[randomIndex].Play();
    }
}
