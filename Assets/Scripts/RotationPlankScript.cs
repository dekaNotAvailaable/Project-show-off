using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RotationPlankScript : MonoBehaviour
{
    public float rotationAngle = 0f;
    public Image blackScreenCanvas;
    private bool hasRotated = false;
    [SerializeField]
    private float blackScreenTime;

    private void Start()
    {
        blackScreenCanvas.enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasRotated)
        {
            StartCoroutine(RotatePlayer(collision.gameObject));
        }
    }

    private IEnumerator RotatePlayer(GameObject player)
    {
        if (blackScreenCanvas != null)
        {
            blackScreenCanvas.enabled = true;
        }
        else
        {
            Debug.LogWarning("Black screen canvas not assigned.");
        }
        yield return new WaitForSeconds(0.1f);
        player.transform.Rotate(Vector3.up, rotationAngle);
        hasRotated = true;
        yield return new WaitForSeconds(blackScreenTime);
        if (blackScreenCanvas != null)
        {
            blackScreenCanvas.enabled = false;
        }

    }
}
