using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
