using UnityEngine;
using System.Collections;
 
public class AudioCollision : MonoBehaviour {
    void OnCollisionEnter(Collision collision) {
 
        if (collision.relativeVelocity.magnitude > 20)
            GetComponent<AudioSource>().Play();
       
        Debug.Log(collision.collider.name);
    }
}