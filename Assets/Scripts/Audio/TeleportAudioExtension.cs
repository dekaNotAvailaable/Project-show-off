using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportAudioExtension : MonoBehaviour
{
    private TeleportationProvider teleportationProvider;

    private void Start()
    {
        teleportationProvider = FindObjectOfType<TeleportationProvider>();

        if (teleportationProvider == null)
        {
            Debug.LogError("TeleportationProvider not found in the scene.");
            return;
        }

        teleportationProvider.endLocomotion += OnTeleport;
    }

    private void OnDestroy()
    {
        if (teleportationProvider != null)
        {
            teleportationProvider.endLocomotion -= OnTeleport;
        }
    }

    private void OnTeleport(LocomotionSystem locomotionSystem)
    {
        AudioManager.instance.TeleportSoundPlay();
    }
}
