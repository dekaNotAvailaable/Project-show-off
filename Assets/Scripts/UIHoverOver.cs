using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

// Make sure your class derives from the correct base class
public class UIHoverOver : MonoBehaviour
{
    public XRRayInteractor leftRayInteractor;
    public XRRayInteractor rightRayInteractor;
    public Canvas targetCanvas;
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
        CheckRaycast(leftRayInteractor);
        CheckRaycast(rightRayInteractor);
    }

    private void CheckRaycast(XRRayInteractor rayInteractor)
    {
        if (rayInteractor && rayInteractor.isActiveAndEnabled)
        {
            if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                if (hit.collider.gameObject == targetCanvas.gameObject)
                {
                    Debug.Log(rayInteractor.name + " is hovering over the canvas area");
                    OnHoverCanvas();
                }
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
