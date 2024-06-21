using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour {
    public AudioSource audioSource; // Assign the player's AudioSource here
    public AudioClip glass;
    public AudioClip normal;
    public float footstepInterval = 0.5f; // Time interval between footsteps
    private float nextFootstepTime = 0f;
    private CharacterController characterController;



    [SerializeField]
    private LayerMask footstepLayerMask; // LayerMask for specific layers to interact with

    void Start() {
        characterController = GetComponent<CharacterController>();
        if (characterController == null) {
            Debug.LogError("FootstepManager: No CharacterController found on the GameObject.");
        }
    }

    void Update() {
        Debug.Log(characterController.velocity.magnitude);
        //Debug.Log(characterController.velocity.magnitude)

        //is grounded check is broken


        if (characterController != null && characterController.isGrounded && characterController.velocity.magnitude > 0.1f) {

            if (Time.time >= nextFootstepTime) {
                // Determine which surface the player is on
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, footstepLayerMask)) {
                    Debug.Log(hit.collider.name);


                    if (hit.collider.CompareTag("glass")) {
                        PlayFootstepSound(glass);
                        Debug.Log("glass ");
                    } else {
                        PlayFootstepSound(normal);
                        Debug.Log("normal ");
                    }
                } else {
                    PlayFootstepSound(normal); // Default to normal if no specific surface is detected
                    Debug.Log("normal alt");
                }
                nextFootstepTime = Time.time + footstepInterval;
            }
        }
    }

    void PlayFootstepSound(AudioClip audio) {
        Debug.Log("Playing sound: " + audio.name); // Add this line for debugging
        audioSource.pitch = Random.Range(0.8f, 1f);
        audioSource.PlayOneShot(audio);
    }
}
