using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CanvasLoader : MonoBehaviour
{
    public GameObject EndMenu;
    public GameObject player;
    public Transform head;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndMenu.SetActive(true);
            player.GetComponent <ContinuousMoveProviderBase>().enabled = false;
            player.GetComponent<ContinuousTurnProviderBase>().enabled = false;
            EndMenu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2;
            EndMenu.transform.LookAt(new Vector3(head.position.x, EndMenu.transform.position.y, head.position.z));
            EndMenu.transform.forward *= -1;
        }
    }
}
