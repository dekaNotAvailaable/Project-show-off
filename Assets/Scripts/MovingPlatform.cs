using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    [SerializeField]
    private float Tolencerance;

    private bool shouldMove = true;
    public GameObject StopPoint;
    public GameObject EndMenu;

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        // Calculate the movement step
        Vector3 movement = direction.normalized * speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, StopPoint.gameObject.transform.position) <= Tolencerance)

        {
            // Stop the platform if a collision is detected
            shouldMove = false;
            EndMenu.SetActive(true);
            Debug.Log("Platform hit: ");
        }
        else
        {
            // Move the platform
            transform.position += movement;
        }
    }
}
