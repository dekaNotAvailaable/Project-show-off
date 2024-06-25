using UnityEngine;

public class CatScript : MonoBehaviour
{
    [SerializeField]
    private float catMoveSpeed;
    [SerializeField]
    private float stopDistance = 3.0f;
    private GameObject nearestNest;
    private bool isNestFound;
    private CatDieAndRespawn catDie;
    public AudioSource NestDestroy;
    void Start()
    {
        catDie = GetComponent<CatDieAndRespawn>();
        FindNearestNest();
    }

    void Update()
    {
        if (nearestNest != null)
        {
            MoveTowardsNest();
        }
        else
        {
            FindNearestNest();
        }

        if (catDie.isDead)
        {
            nearestNest = null;
        }
    }

    private void FindNearestNest()
    {
        GameObject[] nests = GameObject.FindGameObjectsWithTag("Nest");
        float minDistance = float.MaxValue;
        nearestNest = null;

        foreach (GameObject nest in nests)
        {
            float distance = Vector3.Distance(transform.position, nest.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestNest = nest;
            }
        }

        if (nearestNest == null)
        {
            if (isNestFound)
            {
                Debug.LogError("No nests found in the scene.");
            }
            isNestFound = false;
        }
    }

    private void DestroyNearestNest()
    {
        if (nearestNest != null)
        {
           
            Destroy(nearestNest);
            nearestNest = null;
            FindNearestNest();
            NestDestroy.Play();

        }
    }

    private void MoveTowardsNest()
    {
        Vector3 direction = (nearestNest.transform.position - transform.position).normalized;
        float distanceToNest = Vector3.Distance(transform.position, nearestNest.transform.position);

        if (distanceToNest <= stopDistance)
        {
            DestroyNearestNest();
            if (!catDie.isDead)
            {
                catDie.CatDead(false);
            }
            return;
        }

        Vector3 newPosition = transform.position + direction * catMoveSpeed * Time.deltaTime;
        transform.position = newPosition;

        if (direction != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime * catMoveSpeed);
        }

        isNestFound = true;
    }
}
