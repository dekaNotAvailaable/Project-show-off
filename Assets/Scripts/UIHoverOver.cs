using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHoverOver : MonoBehaviour
{
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;
    public LayerMask targetCanvas;
    public TMP_Text texts;
    public Image gunImage;

    [SerializeField]
    private Vector3 imageRaiseCap = new Vector3(0, 10f, 0);

    private Vector3 initialPosition;
    [SerializeField]
    private const float hoverSpeed = 0.4f;

    private void Start()
    {
        texts.enabled = false;
        initialPosition = gunImage.transform.position;
    }

    private void Update()
    {
        CheckController(leftControllerTransform);
        CheckController(rightControllerTransform);
    }

    private void CheckController(Transform controllerTransform)
    {
        RaycastHit hit;
        // Cast a ray from the controller forward
        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, Mathf.Infinity, targetCanvas))
        {
            Debug.Log("Raycast hit detected");
            OnHoverCanvas();
        }
        else
        {
            // Draw a red ray in the Scene view to visualize when the raycast fails
            Debug.DrawRay(controllerTransform.position, controllerTransform.forward * 10, Color.red, 1.0f);
        }
    }

    private void OnHoverCanvas()
    {
        if (gunImage.transform.position.y < initialPosition.y + imageRaiseCap.y)
        {
            gunImage.transform.position += new Vector3(0, hoverSpeed * Time.deltaTime, 0);
            texts.enabled = true;
        }
        else
        {
            gunImage.transform.position = initialPosition + new Vector3(0, imageRaiseCap.y, 0);
        }
    }
}
