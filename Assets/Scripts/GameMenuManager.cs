using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Transform head;
    public float spawnDistance = 2;
    public InputActionProperty showButton;

    void Update()
    {
        //if (menu != null)
        //{
        //    if (showButton.action.WasPressedThisFrame())
        //    {
        //        menu.SetActive(!menu.activeSelf);
        //        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        //    }
        //    if (head != null)
        //    {
        //        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        //        menu.transform.forward *= -1;
        //    }
        //}
        for(int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            gameObjects[i].transform.LookAt(new Vector3(head.position.x, gameObjects[i].transform.position.y, head.position.z));
            gameObjects[i].transform.forward *= -1;
        }
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (showButton.action.WasPressedThisFrame())
            {
                gameObjects[0].SetActive(!gameObjects[0].activeSelf);
            }
        }
    }
}
