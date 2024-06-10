using UnityEngine;
using System.Collections;
 
public class AudioCollision : MonoBehaviour {
    public float magnitude = 20.0f;
    void OnCollisionEnter(Collision collision) {
 
        if (collision.relativeVelocity.magnitude > magnitude)
            GetComponent<AudioSource>().Play();
       
        Debug.Log(collision.collider.name);
    }
}