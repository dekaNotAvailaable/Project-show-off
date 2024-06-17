using UnityEngine;

public class CatRespawnButton : MonoBehaviour
{
    private CatDieAndRespawn catDieAndRespawn;
    private MovingPlatform movingPlatform;

    void Start()
    {
        movingPlatform = GetComponent<MovingPlatform>();
        catDieAndRespawn = FindAnyObjectByType<CatDieAndRespawn>();
        catDieAndRespawn.gameObject.SetActive(false);
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
            catDieAndRespawn.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("CatDieAndRespawn script is not assigned.");
        }
    }
}
