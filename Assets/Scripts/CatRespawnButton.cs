using UnityEngine;

public class CatRespawnButton : MonoBehaviour
{
    [SerializeField] private CatDieAndRespawn catDieAndRespawn;

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public void SpawnCatButton()
    {
        if (catDieAndRespawn != null)
        {
            catDieAndRespawn.RespawnAtFirstPoint();
            this.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("CatDieAndRespawn script is not assigned.");
        }
    }
}
