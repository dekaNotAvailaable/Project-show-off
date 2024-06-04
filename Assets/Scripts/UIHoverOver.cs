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
    public GameObject canvas;
    public Image gunImage;
    [SerializeField]
    private Vector3 imageRaiseCap = new Vector3(0, 10f, 0);
    private Vector3 initialPosition = Vector3.zero;
    [SerializeField]
    private float riseSpeed = 0.4f;
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

    void CheckController(Transform controllerTransform)
    {
        RaycastHit hit;
        if (canvas.activeSelf)
        {
            if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log("casting a ray");
                if (hit.collider != null)
                {
                    // Debug.Log("collider not null");
                    // if (hit.collider.gameObject.CompareTag("Canvas"))
                    //{
                    Debug.Log("raycast is hitting canvas");
                    OnHoverCanvas();
                    //}
                }
                else { Debug.Log("collider null"); }

            }
            else
            {
                Debug.DrawRay(controllerTransform.position, controllerTransform.forward * 10, Color.red, 1.0f);
            }
        }
    }
    private void OnHoverCanvas()
    {
        if (gunImage.transform.position.y < initialPosition.y + imageRaiseCap.y)
        {

            gunImage.transform.position += new Vector3(0, riseSpeed, 0) * Time.deltaTime;
            texts.enabled = true;
            Debug.Log("go up pictue");

        }
        else
        {
            Debug.Log("no go up pictue");
            gunImage.transform.position += Vector3.zero;
        }
    }
}