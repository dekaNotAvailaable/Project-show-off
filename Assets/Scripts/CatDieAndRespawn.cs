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
    private float catRespawnDelay = 1f;
    private Dictionary<GameObject, bool> respawnPoints = new Dictionary<GameObject, bool>();
    [SerializeField]
    private float invisibilityDuration = 5f;
    private float invisibilityTimer;
    private bool isInvisible;
    private CatSoundManage catSounds;
    private bool noAvailableRespawnPoints = false;
    private Score score;
    private bool isHit = false;

    public ParticleSystem smokeParticle;

    private void Start()
    {
        foreach (GameObject point in CatSpawnPoint)
        {
            respawnPoints[point] = false;
        }
        invisibilityTimer = invisibilityDuration;
        catSounds = GetComponent<CatSoundManage>();
        score = FindAnyObjectByType<Score>();
    }

    private void Update()
    {
        if (isInvisible)
        {
            ManageInvisibility();
        }
    }

    public void CatDead(bool diedFromParticles)
    {
        if (!isDead)
        {
            isDead = true;
            Debug.Log("Cat died.");
            smokeParticle.Play();
            if (diedFromParticles)
            {
                score.CatDieScore++;
            }
            if (!noAvailableRespawnPoints)
            {
                StartCoroutine(RespawnWithDelay(CatSpawnPoint, catRespawnDelay, respawnPoints));
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water") && !isInvisible)
        {
            CatDead(false);
            Debug.Log("Cat died due to water.");
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        isHit = true;
        int random = Random.Range(4, 6);
        if (isHit)
        {
            isHit = false;
        }
        if (!isInvisible)
        {
            catSounds.PlayAudioSource(random);
        }
        if (!isInvisible)
        {
            CatDead(true);
            Debug.Log("Cat died due to particle collision.");
        }
    }

    private void ManageInvisibility()
    {
        if (invisibilityTimer > 0)
        {
            invisibilityTimer -= Time.deltaTime;
            if (invisibilityTimer <= 0)
            {
                invisibilityTimer = 0;
                isInvisible = false;
                Debug.Log("Cat is no longer invisible.");
            }
        }
    }

    public void RespawnAtFirstPoint()
    {
        if (CatSpawnPoint.Length > 0)
        {
            GameObject firstPoint = CatSpawnPoint[0];
            this.transform.position = firstPoint.transform.position;
            this.transform.rotation = firstPoint.transform.rotation;
            respawnPoints[firstPoint] = true;
            isDead = false;
            SetInvincibility();
            Debug.Log("Cat respawned at the first point: " + firstPoint.name);
        }
        else
        {
            Debug.LogError("No spawn points available.");
        }
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
                SetInvincibility();
                Debug.Log("Cat respawned at point: " + nearestNest[i].name);
                yield break;
            }
        }
        noAvailableRespawnPoints = true;
        Debug.Log("No available respawn points. Cat will not respawn.");
        Destroy(gameObject);
    }

    private void SetInvincibility()
    {
        isInvisible = true;
        invisibilityTimer = invisibilityDuration;
        Debug.Log("Cat is now invisible.");
    }
}
