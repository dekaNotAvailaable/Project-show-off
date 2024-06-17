using UnityEngine;

public class CatRespawnButton : MonoBehaviour
{
    private MovingPlatform movingPlatform;
    private CatDieAndRespawn[] catDieAndRespawns;

    void Start()
    {
        catDieAndRespawns = FindObjectsOfType<CatDieAndRespawn>();
        movingPlatform = GetComponentInParent<MovingPlatform>();

        if (movingPlatform != null)
        {
            Debug.Log("Moving platform found");
        }

        SetCatActiveAndNot(false);
    }

    void Update()
    {
    }
    private void OnParticleCollision(GameObject other)
    {
        SpawnCatButton();
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
