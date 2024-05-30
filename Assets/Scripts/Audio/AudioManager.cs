using FMODUnity;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than 1 Audio manager in the scene.");
        
        }
        instance = this;
    }

    public void PLayOneShot(EventReference sound, Vector3 worldPos) { 
    RuntimeManager.PlayOneShot(sound, worldPos);
    }
}
