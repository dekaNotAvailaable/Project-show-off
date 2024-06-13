using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    [SerializeField]
    private float catMoveSpeed;
    [SerializeField]
    private float stopDistance = 3.0f;
    private GameObject nearestNest;
    private GameObject nearestCatPoint;
    [SerializeField]
    private int catRespawnDelay = 1;
    private bool isNestFound;
    private CatDieAndRespawn catDie;
    private Dictionary<GameObject, bool> respawnPoints = new Dictionary<GameObject, bool>();

    void Start()
    {
        catDie = GetComponent<CatDieAndRespawn>();
        InitializeRespawnPoints();
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
            catDie.Respawn(nearestCatPoint, catRespawnDelay, respawnPoints);
            FindNearestNest();
        }
    }

    private void InitializeRespawnPoints()
    {
        GameObject[] catRespawnPoints = GameObject.FindGameObjectsWithTag("CatRespawnPoint");
        foreach (GameObject point in catRespawnPoints)
        {
            respawnPoints[point] = false;
        }
    }

    private void FindNearestNest()
    {
        GameObject[] nests = GameObject.FindGameObjectsWithTag("Nest");
        float minDistance = float.MaxValue;
        nearestNest = null;
        nearestCatPoint = null;

        foreach (var entry in respawnPoints)
        {
            GameObject catRespawnPoint = entry.Key;
            bool isUsed = entry.Value;

            if (!isUsed)
            {
                float distance = Vector3.Distance(transform.position, catRespawnPoint.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCatPoint = catRespawnPoint;
                }
            }
        }

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

    private void MoveTowardsNest()
    {
        Vector3 direction = (nearestNest.transform.position - transform.position).normalized;
        float distanceToNest = Vector3.Distance(transform.position, nearestNest.transform.position);
        if (distanceToNest <= stopDistance)
        {
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