using UnityEngine;

public class CatRespawnButton : MonoBehaviour
{
    private CatDieAndRespawn catDieAndRespawn;
    private MovingPlatform movingPlatform;

    void Start()
    {
        movingPlatform = GetComponentInParent<MovingPlatform>();
        catDieAndRespawn = FindAnyObjectByType<CatDieAndRespawn>();
        if (catDieAndRespawn != null)
        {
            // catDieAndRespawn.gameObject.SetActive(false);
            Debug.Log("cat die and respawn found");
        }
        if (movingPlatform != null)
        {
            Debug.Log("moving platform found");
        }
    }

    void Update()
    {

    }

    public void SpawnCatButton()
    {
        if (catDieAndRespawn != null)
        {
            Debug.Log("cat die and respan script not null");
            if (movingPlatform != null)
            {
                Debug.Log("moving platforn is not null");
                movingPlatform._shouldMove = true;
            }
            catDieAndRespawn.RespawnAtFirstPoint();
            catDieAndRespawn.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("CatDieAndRespawn script is not assigned.");
        }
    }
}
