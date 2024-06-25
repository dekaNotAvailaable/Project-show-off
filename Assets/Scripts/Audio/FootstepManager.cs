using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour {
    public AudioSource audioSource; // Assign the AudioSource for footsteps here
    public AudioClip concrete; // Assign the AudioClip for concrete footsteps here
    public AudioClip glass; // Assign the AudioClip for glass footsteps here

    RaycastHit hit;
    public Transform rayStart;
    public float range = 1.0f; // Set a default range if not set in the Editor
    public LayerMask layerMask;
    public float footstepInterval = 0.5f; // Interval between footsteps in seconds

    private void Start() {
        if (audioSource == null) {
            Debug.LogError("AudioSource is not assigned!");
            return;
        }

        if (concrete == null || glass == null) {
            Debug.LogError("One or more AudioClips are not assigned!");
            return;
        }

        if (rayStart == null) {
            Debug.LogError("RayStart Transform is not assigned!");
            return;
        }

        // Start the footstep coroutine
        StartCoroutine(FootstepRoutine());
    }

    private IEnumerator FootstepRoutine() {
        while (true) {
            Footstep();
            yield return new WaitForSeconds(footstepInterval);
        }
    }

    public void Footstep() {
        if (Physics.Raycast(rayStart.position, -rayStart.transform.up, out hit, range, layerMask)) {
            Debug.Log("Raycast hit: " + hit.collider.tag);

            if (hit.collider.CompareTag("Concrete")) {
                PlayFootstepSound(concrete);
                Debug.Log("Concrete Played");
            } else if (hit.collider.CompareTag("Glass")) {
                PlayFootstepSound(glass);
                Debug.Log("Glass Played");
            } else {
                Debug.Log("Hit an object that is not tagged as Concrete or Glass");
            }
        } else {
            Debug.Log("Raycast did not hit anything");
        }
    }

    void PlayFootstepSound(AudioClip audio) {
        audioSource.pitch = Random.Range(0.8f, 1.2f); // Adjust pitch for variety
        audioSource.PlayOneShot(audio);
        Debug.Log("Playing sound: " + audio.name);
    }

    private void Update() {
        Debug.DrawRay(rayStart.position, -rayStart.transform.up * range, Color.red);

        // Temporary test: call Footstep on key press (Remove or replace this in VR setup)
        if (Input.GetKeyDown(KeyCode.F)) {
            Footstep();
        }
    }
}
