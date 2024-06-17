using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDieAndRespawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] CatSpawnPoint;
    [HideInInspector]
    public bool isDead;
    [SerializeField]
    private int catRespawnDelay = 1;
    private Dictionary<GameObject, bool> respawnPoints = new Dictionary<GameObject, bool>();

    private void Start()
    {
        foreach (GameObject point in CatSpawnPoint)
        {
            respawnPoints[point] = false;
        }
    }

    private void CatDead()
    {
        if (!isDead)
        {
            isDead = true;
            Debug.Log("Cat died.");
            StartCoroutine(RespawnWithDelay(CatSpawnPoint, catRespawnDelay, respawnPoints));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            CatDead();
            Debug.Log("cat died due to water.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        CatDead();
        Debug.Log("cat died due to particle collision.");
    }

    private IEnumerator RespawnWithDelay(GameObject[] nearestNest, float delay, Dictionary<GameObject, bool> respawnPoints)
    {
        yield return new WaitForSeconds(delay);

        for (int i = 0; i < nearestNest.Length; i++)
        {
            if (!respawnPoints[nearestNest[i]])
            {
                this.transform.position = nearestNest[i].transform.position;
                this.transform.rotation = nearestNest[i].transform.rotation;
                respawnPoints[nearestNest[i]] = true;
                isDead = false;
                Debug.Log("Cat respawned at point: " + nearestNest[i].name);
                yield break;
            }
        }

        Debug.Log("No available respawn points.");
    }
}
