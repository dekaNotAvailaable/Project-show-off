using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //private void OnTriggerEnter(Collider collision)
    //{
    //    if(collision.gameObject.CompareTag("Player"))
    //    {
    //        if (SceneManager.GetActiveScene().buildIndex == 0)
    //        {
    //            SceneManager.LoadScene(1);
    //        }
    //        else
    //        {
    //            SceneManager.LoadScene(0);
    //        }
    //    }
    //}
    public void WalkingLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void ShootingLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
