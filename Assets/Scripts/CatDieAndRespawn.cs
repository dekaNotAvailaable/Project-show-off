using UnityEngine;

public class CatDieAndRespawn : MonoBehaviour
{
    private bool isCatDead;
    private bool isDying;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CatDie()
    {
        if (!isDying)
        {
            isCatDead = true;
            isDying = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            CatDie();
            Debug.Log("cat died");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision != null)
        //{
        //    CatDie();
        //    Debug.Log("cat died");

        //}
    }
    private void OnParticleCollision(GameObject other)
    {
        CatDie();
        Debug.Log("cat died");
    }
}
