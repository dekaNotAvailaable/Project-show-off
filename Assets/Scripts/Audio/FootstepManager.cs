using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour {
    public AudioSource glassSource; // Assign the AudioSource for glass footsteps here
    public AudioSource normalSource; // Assign the AudioSource for normal footsteps here
    public float footstepInterval = 0.3f; // Time interval between footsteps
    private float nextFootstepTime = 0f;
    private CharacterController characterController;

    private Vector3 lastPosition;

    [SerializeField]
    private LayerMask footstepLayerMask; // LayerMask for specific layers to interact with

    void Start() {
        lastPosition = transform.position;
        characterController = GetComponent<CharacterController>();
        if (characterController == null) {
            Debug.LogError("FootstepManager: No CharacterController found on the GameObject.");
        }
    }

    void Update() {

        float deltaDistance = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;

        
        if (characterController != null && characterController.isGrounded && deltaDistance > 0.1f) {
           

            if (Time.time >= nextFootstepTime) {
                // Determine which surface the player is on
                RaycastHit hit;
                Vector3 rayOrigin = transform.position + Vector3.up * 0.1f; // Start the ray slightly above the player's feet
                if (Physics.Raycast(rayOrigin, Vector3.down, out hit, 1f, footstepLayerMask)) {
                    Debug.Log("Raycast hit: " + hit.collider.name);
                   

                    if (hit.collider.CompareTag("Glass")) {
                        Debug.Log("Glass surface detected");
                        PlayFootstepSound(glassSource);
                    } else {
                        Debug.Log("Normal surface detected");
                        PlayFootstepSound(normalSource);
                    }
                } else {
                    Debug.Log("Raycast did not hit any specific surface");
                    PlayFootstepSound(normalSource); // Default to normal if no specific surface is detected
                }
                nextFootstepTime = Time.time + footstepInterval;
            }
        } else {
        //    Debug.Log("Character is not grounded or not moving");
        }
    }

    void PlayFootstepSound(AudioSource source) {
        if (source != null) {
            Debug.Log("Playing sound: " + source.clip.name); // Add this line for debugging
            source.pitch = Random.Range(0.8f, 1.2f); // Adjust pitch for variety
            source.Play();
        } else {
            Debug.LogWarning("Footstep audio source is null.");
        }
    }
}
