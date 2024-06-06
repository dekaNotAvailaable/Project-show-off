using UnityEngine;
using System.Collections;
 
public class AudioWalking : MonoBehaviour {




    
    void OnCollisionStay(Collision collision) {
 
        if (collision.relativeVelocity.magnitude > 0)
        
            if (Input.GetKey("up"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("w"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("down"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("s"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("right"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("d"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("left"))
        {
            GetComponent<AudioSource>().Play();
        }
            else if (Input.GetKey("s"))
        {
            GetComponent<AudioSource>().Play();
        }
       
        
        Debug.Log(collision.collider.name);
    }
}