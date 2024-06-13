using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatDieAndRespawn : MonoBehaviour
{
    [HideInInspector]
    public bool isDead;
    private void CatDead()
    {
        if (!isDead)
        {
            isDead = true;
        }
        else
        {
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            CatDead();
            Debug.Log("cat died");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        CatDead();
        Debug.Log("cat died");
    }

    public void Respawn(GameObject nest, float delay, Dictionary<GameObject, bool> respawnPoints)
    {
        if (isDead && nest != null)
        {
            StartCoroutine(RespawnWithDelay(nest, delay, respawnPoints));
        }
        else if (nest == null)
        {
            Debug.Log("nest is null");
        }
    }

    private IEnumerator RespawnWithDelay(GameObject nearestNest, float delay, Dictionary<GameObject, bool> respawnPoints)
    {
        yield return new WaitForSeconds(delay);
        this.transform.position = nearestNest.transform.position;
        this.transform.rotation = nearestNest.transform.rotation;
        respawnPoints[nearestNest] = true;
        isDead = false;
        this.enabled = true;
    }
}