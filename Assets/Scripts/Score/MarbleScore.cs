using UnityEngine;

public class MarbleScore : MonoBehaviour
{
    private Score score;
    private void Start()
    {
        score = FindAnyObjectByType<Score>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Marble"))
        {
            if (score != null)
            {
                score.MarbleScore += 1;
            }
        }
    }
}
