using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
    public static FMODEvents instances { get; private set; }

    private void Awake() {
        if (instances == null) {
            Debug.LogError("Found more than one FMOD Event script in the scene");
        }
    }
}
