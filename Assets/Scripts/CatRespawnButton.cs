using System.Collections;
using UnityEngine;
public class CatRespawnButton : MonoBehaviour
{
    private MovingPlatform movingPlatform;
    private CatDieAndRespawn[] catDieAndRespawns;
    public GameObject UnpressedButton;
    public GameObject PressedButton;
    public bool cat;
    void Start()
    {
        catDieAndRespawns = FindObjectsOfType<CatDieAndRespawn>();
        movingPlatform = FindAnyObjectByType<MovingPlatform>();
        if(PressedButton != null )
        PressedButton.gameObject.SetActive(false);
        if( UnpressedButton != null )
        UnpressedButton.gameObject.SetActive(true);
        if (movingPlatform != null)
        {
            //Debug.Log("Moving platform found");
        }

        SetCatActiveAndNot(false);
    }
    private void OnParticleCollision(GameObject other)
    {
        SpawnCatButton();
     //   StartCoroutine(ButtonPressedAndRelease());
    }
    private IEnumerator ButtonPressedAndRelease()
    {
        if(PressedButton != null)
        PressedButton.gameObject.SetActive(true);
        if( UnpressedButton != null )
        UnpressedButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        if(UnpressedButton != null )
        UnpressedButton.gameObject.SetActive(true);
        if(PressedButton != null)
        PressedButton.gameObject.SetActive(false);
    }
    public void SpawnCatButton()
    {
        if (movingPlatform != null)
        {
            //Debug.Log("Moving platform is not null");
            movingPlatform._shouldMove = true;
        }

        foreach (CatDieAndRespawn catDieAndRespawn in catDieAndRespawns)
        {
            catDieAndRespawn.RespawnAtFirstPoint();
            catDieAndRespawn.gameObject.SetActive(true);
            //Debug.Log("Cat respawned and activated: " + catDieAndRespawn.gameObject.name);

        }
    }
    private void SetCatActiveAndNot(bool isActive)
    {
        //cat = isActive;
        foreach (CatDieAndRespawn catDieAndRespawn in catDieAndRespawns)
        {
            catDieAndRespawn.gameObject.SetActive(isActive);
        }
    }
}
