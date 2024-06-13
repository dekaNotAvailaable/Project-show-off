using System.Collections;
using UnityEngine;
public class CatDieAndRespawn : MonoBehaviour
{
    [HideInInspector]
    public bool isDead;
    private bool isUsed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CatDead()
    {
        if (!isDead)
        {
            //isCatDead = true;
            isDead = true;
            //Destroy(gameObject);
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
    public void Respawn(GameObject nest, float delay)
    {
        if (isDead && nest != null)
        {
            StartCoroutine(RespawnWithDelay(nest, delay));

        }
        else if (nest == null)
        {
            Debug.Log("nest is null");
        }
    }

    private IEnumerator RespawnWithDelay(GameObject nearestNest, float delay)
    {
        yield return new WaitForSeconds(delay);
        this.transform.position = nearestNest.transform.position;
        // nearestNest.
        isDead = false;
        this.enabled = true;
    }

}
