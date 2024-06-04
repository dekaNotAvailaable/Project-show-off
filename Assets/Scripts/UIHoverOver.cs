using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Make sure your class derives from the correct base class
public class UIHoverOver : MonoBehaviour
{
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;
    public LayerMask targetCanvas;
    public TMP_Text texts;
    public Image gunImage;
    [SerializeField]
    private Vector3 imageRaiseCap = new Vector3(0, 10f, 0);
    private void Start()
    {
        texts.enabled = false;
    }
    private void Update()
    {
        CheckController(leftControllerTransform);
        CheckController(rightControllerTransform);
    }

    void CheckController(Transform controllerTransform)
    {
        RaycastHit hit;
        // Cast a ray from the controller forward
        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, Mathf.Infinity, targetCanvas))
        {
            // Check if the raycast hit the canvas
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Canvas"))
            {
                // Perform your action here
                OnHoverCanvas();
            }
        }
    }
    private void OnHoverCanvas()
    {
        if (gunImage.transform.position.y < gunImage.transform.position.y + imageRaiseCap.y)
        {
            gunImage.transform.position += new Vector3(0, 1, 0);
            texts.enabled = true;
        }
    }
}
