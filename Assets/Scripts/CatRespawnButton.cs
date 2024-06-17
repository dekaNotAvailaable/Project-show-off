using UnityEngine;

public class CatRespawnButton : MonoBehaviour
{
    private MovingPlatform movingPlatform;

    void Start()
    {
        movingPlatform = GetComponentInParent<MovingPlatform>();
        if (movingPlatform != null)
        {
            Debug.Log("Moving platform found");
        }
    }

    void Update()
    {
    }

    public void SpawnCatButton()
    {
        if (movingPlatform != null)
        {
            Debug.Log("Moving platform is not null");
            movingPlatform._shouldMove = true;
        }
        CatDieAndRespawn[] catDieAndRespawns = FindObjectsOfType<CatDieAndRespawn>();
        if (catDieAndRespawns != null)
        {
            Debug.Log("CatDieAndRespawn scripts found: " + catDieAndRespawns.Length);
            foreach (CatDieAndRespawn catDieAndRespawn in catDieAndRespawns)
            {

                catDieAndRespawn.RespawnAtFirstPoint();
                catDieAndRespawn.gameObject.SetActive(true);
                Debug.Log("Cat respawned and activated: " + catDieAndRespawn.gameObject.name);
            }
        }
        else
        {
            Debug.LogError("No CatDieAndRespawn scripts found.");
        }
    }
}
