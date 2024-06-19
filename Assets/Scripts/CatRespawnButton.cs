using System.Collections;
using UnityEngine;
public class CatRespawnButton : MonoBehaviour
{
    private MovingPlatform movingPlatform;
    private CatDieAndRespawn[] catDieAndRespawns;
    public GameObject UnpressedButton;
    public GameObject PressedButton;
    void Start()
    {
        catDieAndRespawns = FindObjectsOfType<CatDieAndRespawn>();
        movingPlatform = FindAnyObjectByType<MovingPlatform>();
        PressedButton.gameObject.SetActive(false);
        UnpressedButton.gameObject.SetActive(true);
        if (movingPlatform != null)
        {
            Debug.Log("Moving platform found");
        }

        SetCatActiveAndNot(false);
    }
    private void OnParticleCollision(GameObject other)
    {
        SpawnCatButton();
        StartCoroutine(ButtonPressedAndRelease());
    }
    private IEnumerator ButtonPressedAndRelease()
    {
        PressedButton.gameObject.SetActive(true);
        UnpressedButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        UnpressedButton.gameObject.SetActive(true);
        PressedButton.gameObject.SetActive(false);
    }
    public void SpawnCatButton()
    {
        if (movingPlatform != null)
        {
            Debug.Log("Moving platform is not null");
            movingPlatform._shouldMove = true;
        }

        foreach (CatDieAndRespawn catDieAndRespawn in catDieAndRespawns)
        {
            catDieAndRespawn.RespawnAtFirstPoint();
            catDieAndRespawn.gameObject.SetActive(true);
            Debug.Log("Cat respawned and activated: " + catDieAndRespawn.gameObject.name);
        }
    }
    private void SetCatActiveAndNot(bool isActive)
    {
        foreach (CatDieAndRespawn catDieAndRespawn in catDieAndRespawns)
        {
            catDieAndRespawn.gameObject.SetActive(isActive);
        }
    }
}
