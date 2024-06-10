using UnityEngine;
using System.Collections;
 
public class AudioCollision : MonoBehaviour {
<<<<<<< HEAD
    public float magnitude = 20.0f;
    void OnCollisionEnter(Collision collision) {
 
        if (collision.relativeVelocity.magnitude > magnitude)
=======
    void OnCollisionEnter(Collision collision) {
 
        if (collision.relativeVelocity.magnitude > 20)
>>>>>>> Sound-Design
            GetComponent<AudioSource>().Play();
       
        Debug.Log(collision.collider.name);
    }
}