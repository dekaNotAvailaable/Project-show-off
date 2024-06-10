
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public AudioSource BGM;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than 1 Audio manager in the scene.");
        
        }
        instance = this;
    }
    private void Start()
    {
        PlayBGM();
    }
    private void PlayBGM() { BGM.Play(); BGM.loop = true; }

}