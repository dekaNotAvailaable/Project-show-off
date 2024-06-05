using UnityEngine;
using UnityEngine.UI;

public class GameCollisionManager : MonoBehaviour
{
    public Image finishScreen;
    void Start()
    {
        finishScreen.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Finish"))
            {
                finishScreen.enabled = true;
                SceneChange.Instance.ChangeSceneToNext();
            }


        }
    }
}
