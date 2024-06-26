using System.Collections;
using UnityEngine;

public class CatSoundManage : MonoBehaviour
{
    private AudioSource[] audioSources;
    private Coroutine catCallingCoroutine;

    private void Start()
    {
        audioSources = GetComponents<AudioSource>();
        if (audioSources.Length == 0)
        {
            //Debug.LogError("No AudioSource components found on this GameObject.");
            return;
        }
    }

    private void OnEnable()
    {
        if (catCallingCoroutine == null)
        {
            catCallingCoroutine = StartCoroutine(PlayCatCalling());
        }
    }

    private void OnDisable()
    {
        if (catCallingCoroutine != null)
        {
            StopCoroutine(catCallingCoroutine);
            catCallingCoroutine = null;
        }
    }

    public void PlayAudioSource(int index)
    {
        if (index < 0 || index >= audioSources.Length)
        {

            //Debug.LogError("AudioSource index out of range.");
            return;
        }
        if (!audioSources[index].isPlaying)
        {
            audioSources[index].Play();
        }
        //Debug.Log("Playing audio clip: " + audioSources[index].clip.name);
    }

    private IEnumerator PlayCatCalling()
    {
        //Debug.Log("Cat calling coroutine started.");
        while (true)
        {
            //Debug.Log("Cat calling starts");
            float waitTime = Random.Range(2f, 10f);
            yield return new WaitForSeconds(waitTime);

            if (audioSources != null && audioSources.Length > 0)
            {
                int randomIndex = Random.Range(2, 4);
                audioSources[randomIndex].Play();
                // Debug.LogWarning("Playing audio clip: " + audioSources[randomIndex].clip.name);
            }
        }
    }
}
