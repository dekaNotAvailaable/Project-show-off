using System.Collections;
using UnityEngine;

public class RotationPlankScript : MonoBehaviour
{
    public float rotationAngle = 0f;
    public GameObject blackScreen;
    private bool hasRotated = false;
    [SerializeField]
    private float blackScreenTime;
    public CharacterController CC;

    private void Start()
    {

        //blackScreen = GameObject.Find("BlackScreen");
        if (blackScreen != null)
        {
            blackScreen.SetActive(false);
            Debug.Log("balckscreen Found");
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasRotated)
        {
            StartCoroutine(RotatePlayer(collision.gameObject));
            Debug.Log("the player has stepped on the rotate plank");
        }
    }

    private IEnumerator RotatePlayer(GameObject player)
    {

        if (blackScreen != null)
        {
            blackScreen.SetActive(true);
            Debug.Log("balckscreen Found v2");
        }
        else
        {
            Debug.LogWarning("Black screen canvas not assigned.");
        }
        yield return new WaitForSeconds(0.1f);
        player.transform.parent.Rotate(Vector3.up, rotationAngle);
        hasRotated = true;
        yield return new WaitForSeconds(blackScreenTime);
        if (blackScreen != null)
        {
            blackScreen.SetActive(false);
        }
        yield return new WaitForSeconds(blackScreenTime + 4f);
        if (hasRotated)
        {
            hasRotated = !hasRotated;
        }



    }
}