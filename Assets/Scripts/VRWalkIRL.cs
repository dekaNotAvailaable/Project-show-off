using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class VRWalkIRL : MonoBehaviour
{
    public float speed = 5f;
    public float amplitude = 2f;
    public float frequency = 0.3f;
    public Vector3 direction = Vector3.forward;
    private Vector3 startPosition;
    private Vector3 lastHeadsetPosition;
    private Vector3 currentHeadsetPosition;
    private XRDisplaySubsystem displaySubsystem;
    private InputDevice headsetDevice;

    public float movementThreshold = 0.01f;

    void Start()
    {
        startPosition = transform.position;
        direction = direction.normalized;
        displaySubsystem = XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRDisplaySubsystem>();
        if (displaySubsystem != null && displaySubsystem.running)
        {
            headsetDevice = InputDevices.GetDeviceAtXRNode(XRNode.Head);
            if (headsetDevice.isValid)
            {
                headsetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out lastHeadsetPosition);
            }
        }
        else
        {
            Debug.LogError("No XR device detected.");
        }
    }

    void Update()
    {
        if (displaySubsystem != null && displaySubsystem.running && headsetDevice.isValid)
        {
            if (headsetDevice.TryGetFeatureValue(CommonUsages.devicePosition, out currentHeadsetPosition))
            {
                Vector3 deltaPosition = currentHeadsetPosition - lastHeadsetPosition;
                if (deltaPosition.magnitude > movementThreshold)
                {
                    transform.position += deltaPosition;
                }
                lastHeadsetPosition = currentHeadsetPosition;
            }
        }
    }
}
