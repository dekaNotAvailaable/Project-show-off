using System.Collections;
using UnityEngine;

public class RotationPlankScript : MonoBehaviour
{
    // Public float for rotation angle
    public float rotationAngle = 0f;

    // Reference to the black screen canvas
    public GameObject blackScreenCanvas;

    // Boolean to check if the rotation has already been done
    private bool hasRotated = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Player" tag and if it hasn't already rotated
        if (collision.gameObject.CompareTag("Player") && !hasRotated)
        {
            // Start the coroutine to rotate the player
            StartCoroutine(RotatePlayer(collision.gameObject));
        }
    }

    private IEnumerator RotatePlayer(GameObject player)
    {
        // Activate the black screen canvas
        if (blackScreenCanvas != null)
        {
            blackScreenCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Black screen canvas not assigned.");
        }

        // Small delay to simulate the effect
        yield return new WaitForSeconds(0.1f);

        // Rotate the player based on the rotation angle
        player.transform.Rotate(Vector3.up, rotationAngle);

        // Deactivate the black screen canvas after the rotation
        if (blackScreenCanvas != null)
        {
            blackScreenCanvas.SetActive(false);
        }

        // Set the hasRotated flag to true to prevent further rotations
        hasRotated = true;
    }
}
