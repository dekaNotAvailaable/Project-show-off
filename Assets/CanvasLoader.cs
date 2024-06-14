using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLoader : MonoBehaviour
{
    public GameObject EndMenu;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EndMenu.SetActive(true);
        }
    }
}
