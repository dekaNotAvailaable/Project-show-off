using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public Transform head;
    public float spawnDistance = 2;
    public InputActionProperty showButton;

    void Update()
    {
        if (menu != null)
        {
            if (showButton.action.WasPressedThisFrame())
            {
                menu.SetActive(!menu.activeSelf);
                menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            }
            if (head != null)
            {
                menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
                menu.transform.forward *= -1;
            }
        }
    }
}
